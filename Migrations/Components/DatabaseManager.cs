#region usings

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

#endregion

namespace Migrations.Components
{
    public class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }
        public int Timeout { get; set; }
        public string ProviderSwitches { get; private set; }
    }

    public class DatabaseManager
    {
        public Action<int, string> OnSqlBackupPercentComplete;
        public Action<int, string> OnSqlRestorePercentComplete;
        public Action<SqlError> OnSqlBackupComplete;
        public Action<SqlError> OnSqlRestoreComplete;
        public Action<string> OnNewUpdateLog;
        public bool IsConnected { get; private set; }
        private ServerConnection _connection;
        private string _userName;
        private string _password;
        private string _serverName;
        private bool _useInteratedLogin;

        public void Connect(string userName, string password, string serverName, bool useInteratedLogin)
        {
            _userName = userName;
            _password = password;
            _serverName = serverName;
            _useInteratedLogin = useInteratedLogin;

            if (useInteratedLogin)
            {
                var sqlCon = new SqlConnection(string.Format("Data Source={0}; Integrated Security=True; Connection Timeout=5", serverName));
                _connection = new ServerConnection(sqlCon);
                _connection.Connect();
                IsConnected = true;
            }
            else
            {
                _connection = new ServerConnection(serverName, userName, password);
                _connection.ConnectTimeout = 5000;
                _connection.Connect();
                IsConnected = true;
            }
        }

        public void BackupDatabase(string databaseName, string destinationPath)
        {
            var sqlServer = new Server(_connection);
            databaseName = databaseName.Replace("[", "").Replace("]", "");
            var sqlBackup = new Backup
                {
                    Action = BackupActionType.Database,
                    BackupSetDescription = "ArchiveDataBase:" + DateTime.Now.ToShortDateString(),
                    BackupSetName = "Archive",
                    Database = databaseName
                };

            var deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);
            sqlBackup.Incremental = false;
            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);

            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
            sqlBackup.PercentCompleteNotification = 10;
            sqlBackup.PercentComplete += (sender, e) => OnSqlBackupPercentComplete(e.Percent, e.Message);
            sqlBackup.Complete += (sender, e) => OnSqlBackupComplete(e.Error);
            sqlBackup.FormatMedia = false;
            sqlBackup.SqlBackup(sqlServer);
        }

        public DatabaseCollection GetDatabasesList()
        {
            if (IsConnected)
            {
                var sqlServer = new Server(_connection);
                return sqlServer.Databases;
            }
            return null;
        }

        public void RestoreDatabase(string databaseName, string filePath)
        {
            var sqlServer = new Server(_connection);

            databaseName = databaseName.Replace("[", "").Replace("]", "");
            
            var sqlRestore = new Restore();
            sqlRestore.PercentCompleteNotification = 10;
            sqlRestore.PercentComplete += (sender, e) => OnSqlRestorePercentComplete(e.Percent, e.Message);
            sqlRestore.Complete += (sender, e) => OnSqlRestoreComplete(e.Error);

            var deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
            sqlRestore.Devices.Add(deviceItem);
            sqlRestore.Database = databaseName;

            DataTable dtFileList = sqlRestore.ReadFileList(sqlServer);

            int lastIndexOf = dtFileList.Rows[1][1].ToString().LastIndexOf(@"\");
            string physicalName = dtFileList.Rows[1][1].ToString().Substring(0, lastIndexOf + 1);
            string dbLogicalName = dtFileList.Rows[0][0].ToString();
            if (!Directory.Exists(physicalName))
            {
                physicalName = sqlServer.MasterDBPath + "\\";
            }

            string dbPhysicalName = physicalName + databaseName + ".mdf";
            string logLogicalName = dtFileList.Rows[1][0].ToString();
            string logPhysicalName = physicalName + databaseName + "_log.ldf";

            sqlRestore.RelocateFiles.Add(new RelocateFile(dbLogicalName, dbPhysicalName));
            sqlRestore.RelocateFiles.Add(new RelocateFile(logLogicalName, logPhysicalName));

            sqlServer.KillAllProcesses(sqlRestore.Database);

            Database db = sqlServer.Databases[databaseName];
            if (db != null)
            {
                db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                db.Alter(TerminationClause.RollbackTransactionsImmediately);
                sqlServer.DetachDatabase(sqlRestore.Database, false);
            }

            sqlRestore.Action = RestoreActionType.Database;
            sqlRestore.ReplaceDatabase = true;

            sqlRestore.SqlRestore(sqlServer);
            db = sqlServer.Databases[databaseName];
            db.SetOnline();
            sqlServer.Refresh();
            db.DatabaseOptions.UserAccess = DatabaseUserAccess.Multiple;
        }

        public void Disconnect()
        {
            if (IsConnected)
                _connection.Disconnect();

            IsConnected = false;
        }

        public void UpdateToLatestVersion(string databaseName, string migrationNamespace)
        {
                var announcer = new TextWriterAnnouncer(OnNewUpdateLog);
                var assembly = Assembly.GetExecutingAssembly();

                var migrationContext = new RunnerContext(announcer)
                {
                    Namespace = migrationNamespace
                };

                var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };
                var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
                var processor = factory.Create(GetConnectionString(databaseName), announcer, options);
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                //runner.SilentlyFail = true;
                //runner.ListMigrations();
                runner.MigrateUp(true);
                OnNewUpdateLog("Done");
        }

        private string GetConnectionString(string databaseName)
        {
            if (!IsConnected)
                throw new Exception("Connection does not exist, connect first");

            return _useInteratedLogin
                ? string.Format("data source={0};initial catalog={1};integrated security=True;MultipleActiveResultSets=True", _serverName, databaseName)
                : string.Format("data source={0};initial catalog={1};integrated security=False;User ID={2};Password={3} ;MultipleActiveResultSets=True", _serverName, databaseName, _userName, _password);
        }
    }
}
