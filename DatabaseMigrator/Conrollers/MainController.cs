#region usings

using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseMigrator.Components;
using DatabaseMigrator.Dtos;
using DatabaseMigrator.Views;
using Migrations.Components;

#endregion

namespace DatabaseMigrator.Conrollers
{
    public class MainController
    {
        private readonly MainForm _view;

        private DatabaseManager _databaseManager;

        public MainController()
        {
            _view = new MainForm();
            SubscribeEvents();
            InitDatabaseManager();
            RestoreUserSettings();
            _view.IsUseIntegratedLogin = true;

            _view.MigrationNamespaces = AppSettings.GetMigrationNamespaces();
        }

        private void RestoreUserSettings()
        {
            _view.HostName = Properties.Settings.Default.HostName;
            _view.UserLogin = Properties.Settings.Default.UserName;
        }

        private void SaveUserSettings()
        {
            Properties.Settings.Default.HostName = _view.HostName;
            Properties.Settings.Default.UserName = _view.UserLogin;
            Properties.Settings.Default.Save();
        }

        public Form Run()
        {
            _view.StartAsyncJob(false, false);
            _view.Disconnected();
            _view.Show();
            return _view;
        }

        private void InitDatabaseManager()
        {
            _databaseManager = new DatabaseManager();
            _databaseManager.OnSqlBackupComplete += DatabaseManagerOnSqlBackupComplete;
            _databaseManager.OnSqlBackupPercentComplete += DatabaseManagerOnSqlBackupPercentComplete;
            _databaseManager.OnSqlRestoreComplete += DatabaseManagerOnSqlRestoreComplete;
            _databaseManager.OnSqlRestorePercentComplete += DatabaseManagerOnSqlRestorePercentComplete;
            _databaseManager.OnNewUpdateLog += DatabaseManagerOnNewUpdateLog;
        }

        private void DatabaseManagerOnNewUpdateLog(string message)
        {
            _view.AddToLog(message);
        }

        private void DatabaseManagerOnSqlBackupComplete(SqlError error)
        {
            if (error != null)
                _view.AddToLog(error.Message);
        }

        private void DatabaseManagerOnSqlBackupPercentComplete(int percent, string message)
        {
            if (!string.IsNullOrEmpty(message))
                _view.AddToLog(message);
            _view.ShowProgressBarPercent(percent);
        }

        private void DatabaseManagerOnSqlRestoreComplete(SqlError error)
        {
            if (error != null)
                _view.AddToLog(error.Message);
        }

        private void DatabaseManagerOnSqlRestorePercentComplete(int percent, string message)
        {
            if (!string.IsNullOrEmpty(message))
                _view.AddToLog(message);
            _view.ShowProgressBarPercent(percent);
        }

        private void SubscribeEvents()
        {
            _view.OnConnectButtonClick += ViewOnConnectButtonClick;
            _view.OnFinishButtonClick += ViewOnFinishButtonClick;
            _view.OnRefreshButtonClick += ViewOnRefreshButtonClick;
        }

        private void ViewOnRefreshButtonClick()
        {
            _view.StartAsyncJob(false, true);
            Task.Factory.StartNew(() => _databaseManager.GetDatabasesList()).ContinueWith(result =>
            {
                _view.StartAsyncJob(false, false);

                _view.ExistDatabaseList = result.Result;
                _view.AddToLog("Database list updated");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ViewOnConnectButtonClick()
        {
            if (_databaseManager.IsConnected)
            {
                Disconnect();
            }
            else
            {
                Connect();
            }
        }

        private void Connect()
        {
            if (_view.HostName == string.Empty)
            {
                _view.AddToLog(@"Please enter Host name!");
                MessageBox.Show(@"Please enter Host name!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_view.IsUseIntegratedLogin && (_view.UserLogin == string.Empty || _view.UserPasswd == string.Empty))
            {
                _view.AddToLog(@"Please enter User Login and User Password!");
                MessageBox.Show(@"Please enter User Login and User Password! ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _view.StartAsyncJob(false, true);
            Task.Factory.StartNew(() => _databaseManager.Connect(_view.UserLogin, _view.UserPasswd, _view.HostName, _view.IsUseIntegratedLogin)).ContinueWith(result =>
                {
                    _view.StartAsyncJob(false, false);
                    if (result.Exception != null)
                    {
                        _view.AddToLog("Connection failed; " + result.Exception.InnerException.Message);
                        return;
                    }
                    _view.Connected();
                    _view.AddToLog("Connected");
                    ViewOnRefreshButtonClick();
                    SaveUserSettings();

                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Disconnect()
        {
            _databaseManager.Disconnect();
            _view.Disconnected();
            _view.AddToLog("Disconnected");
        }

        private void ViewOnFinishButtonClick()
        {
            if (_view.IsCreateOperationType)
            {
                CreateDatabase();
                return;
            }
            if (_view.IsUpdateOperationType)
            {
                UpdateDatabase();
                return;
            }
            if (_view.IsRestoreOperationType)
            {
                RestoreDatabase();
                return;
            }

            if (_view.IsBackupOperationType)
            {
                BackupDatabase();
                return;
            }
            _view.AddToLog(@"Please select operation type!");
            MessageBox.Show(@"Please select operation type!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CreateDatabase()
        {
            string selectedBackFile = GetSelectedBackFilePath();

            if (selectedBackFile != string.Empty)
            {
                RestoreDatabaseTask(_view.NewDatabaseName, selectedBackFile);
            }
        }

        private void RestoreDatabaseTask(string dbname, string backupFilePath)
        {

            _view.StartAsyncJob(true, true);
            Task.Factory.StartNew(() => _databaseManager.RestoreDatabase(dbname, backupFilePath)).ContinueWith(result =>
            {
                _view.StartAsyncJob(false, false);
                if (result.Exception != null)
                {
                    _view.AddToLog("Creation database" + dbname + " failed; " + result.Exception.InnerException.Message);
                    return;
                }
                _view.AddToLog("Creation database" + dbname + " done");

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void UpdateToLatestVesionDatabaseTask(string dbname, string migrationNamespace)
        {

            _view.StartAsyncJob(false, true);
            Task.Factory.StartNew(() => _databaseManager.UpdateToLatestVersion(dbname, migrationNamespace)).ContinueWith(result =>
            {
                _view.StartAsyncJob(false, false);
                if (result.Exception != null)
                {
                    _view.AddToLog("Update database" + dbname + " to latest version failed; " + result.Exception.InnerException.Message);
                    return;
                }
                _view.AddToLog("Update database" + dbname + " to latest version done");

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void UpdateDatabase()
        {
            if (_view.GetSelectedExistDatabase() == string.Empty)
            {
                _view.AddToLog(@"Please select database!");
                MessageBox.Show(@"Please select database!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MigrationNamespace selectedigrationNamespace = _view.SelectedigrationNamespace;

            if (selectedigrationNamespace != null)
            {
                UpdateToLatestVesionDatabaseTask(_view.GetSelectedExistDatabase(), selectedigrationNamespace.Path);
                return;
            }

            _view.AddToLog(@"Please select migration namespace!");
            MessageBox.Show(@"Please select migration namespace!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RestoreDatabase()
        {
            if (_view.GetSelectedExistDatabase() == string.Empty)
            {
                _view.AddToLog(@"Please select exist database for backup!");
                MessageBox.Show(@"Please select exist database for backup!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;


            _view.StartAsyncJob(true, true);
            Task.Factory.StartNew(() => _databaseManager.RestoreDatabase(_view.GetSelectedExistDatabase(), openFileDialog.FileName)).ContinueWith(result =>
            {
                _view.StartAsyncJob(false, false);
                if (result.Exception != null)
                {
                    _view.AddToLog("Restore failed; " + result.Exception.InnerException.Message);
                }

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BackupDatabase()
        {
            if (_view.GetSelectedExistDatabase() == string.Empty)
            {
                _view.AddToLog(@"Please select exist database for backup!");
                MessageBox.Show(@"Please select exist database for backup!", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var openFileDialog = new SaveFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            if (File.Exists(openFileDialog.FileName))
            {
                File.Delete(openFileDialog.FileName);
            }
            _view.StartAsyncJob(true, true);
            Task.Factory.StartNew(() => _databaseManager.BackupDatabase(_view.GetSelectedExistDatabase(), openFileDialog.FileName)).ContinueWith(result =>
                {
                    _view.StartAsyncJob(false, false);
                    if (result.Exception != null)
                    {
                        _view.AddToLog("Backup failed; " + result.Exception.InnerException.Message);
                    }

                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private string GetSelectedBackFilePath()
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return string.Empty;
            }

            return openFileDialog.FileName;
        }
    }
}
