using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using FluentMigrator;
using FluentMigrator.Builders.Execute;

namespace Migrations.Components
{
    public static class ScriptExecutor
    {
        private const string PathToMetabaseDbSqlFiles = @"SqlFiles";

        public static void ExecuteScriptsFromFolder(string folderName, IExecuteExpressionRoot  expressionRoot)
        {
            string path = string.Format("{0}\\{1}\\{2}", Environment.CurrentDirectory, PathToMetabaseDbSqlFiles,folderName);
            string[] filePaths = Directory.GetFiles(path).OrderBy(q => q).ToArray();
            foreach (var filePath in filePaths)
            {
                expressionRoot.Script(filePath);
            }
        }

        public static string GetDatabaseName(Migration migration)
        {
            var builder = new SqlConnectionStringBuilder(migration.ConnectionString);
            return builder.InitialCatalog;
        }
    }
}
