#region usings

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseMigrator.Dtos;
using Microsoft.SqlServer.Management.Smo;

#endregion

namespace DatabaseMigrator.Views
{
    public partial class MainForm : Form
    {
        public Action OnConnectButtonClick;
        public Action OnFinishButtonClick;
        public Action OnRefreshButtonClick;

        public MainForm()
        {
            InitializeComponent();
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            connectButton.Click += (sender, e) => OnConnectButtonClick();
            finishButton.Click += (sender, e) => OnFinishButtonClick();
            refreshButton.Click += (sender, e) => OnRefreshButtonClick();
            useIntegratedLoginCheckBox.CheckedChanged += (sender, e) => useIntegratedLoginCheckBox_Click();
            createDBRadioButton.Click += (sender, e) => createDBRadioButton_Click();
            updateDBRadioButton.Click += (sender, e) => updateDBRadioButton_Click();
            restoreRadioButton.Click += (sender, e) => updateDBRadioButton_Click();
            backupRadioButton.Click += (sender, e) => updateDBRadioButton_Click();
        }


        private void updateDBRadioButton_Click()
        {
            ExistDBComboBox.Enabled = !createDBRadioButton.Checked;
            newDBNameTextBox.Enabled = createDBRadioButton.Checked;
        }

        private void createDBRadioButton_Click()
        {
            ExistDBComboBox.Enabled = updateDBRadioButton.Checked;
            newDBNameTextBox.Enabled = !updateDBRadioButton.Checked;
        }

        private void useIntegratedLoginCheckBox_Click()
        {
            passwdTextBox.Enabled = loginTextBox.Enabled = !useIntegratedLoginCheckBox.Checked;
        }

        public string HostName
        {
            get { return hostNameTextBox.Text; }
            set { hostNameTextBox.Text = value; }
        }

        public string UserLogin
        {
            get { return loginTextBox.Text; }
            set { loginTextBox.Text = value; }
        }

        public string UserPasswd
        {
            get { return passwdTextBox.Text; }
            set { passwdTextBox.Text = value; }
        }

        public bool IsUseIntegratedLogin
        {
            get { return useIntegratedLoginCheckBox.Checked; }
            set { useIntegratedLoginCheckBox.Checked = value; }
        }

        public bool IsCreateOperationType
        {
            get { return createDBRadioButton.Checked; }
        }

        public bool IsUpdateOperationType
        {
            get { return updateDBRadioButton.Checked; }
        }

        public bool IsRestoreOperationType
        {
            get { return restoreRadioButton.Checked; }
        }

        public bool IsBackupOperationType
        {
            get { return backupRadioButton.Checked; }
        }

        public List<MigrationNamespace> MigrationNamespaces
        {
            set { migrationNamespaceBindingSource.DataSource = value; }
            get { return migrationNamespaceBindingSource.DataSource as List<MigrationNamespace>; }
        }

        public MigrationNamespace SelectedigrationNamespace
        {
            get { return migrationNamespaceBindingSource.Current as MigrationNamespace; }
        }

        public string NewDatabaseName
        {
            get { return newDBNameTextBox.Text; }
            set { newDBNameTextBox.Text = value; }
        }

        delegate string StringInvoker();

        public string GetSelectedExistDatabase()
        {
            if (ExistDBComboBox.InvokeRequired)
            {
                return (string)Invoke(new StringInvoker(GetSelectedExistDatabase));
            }
            else
            {
                return (ExistDBComboBox.Text.Replace("[", "").Replace("]",""));
            }
        }

        public DatabaseCollection ExistDatabaseList
        {
            set
            {
                ExistDBComboBox.Items.Clear();
                foreach (Database database in value)
                {
                    if (database.IsSystemObject)
                        continue;

                    ExistDBComboBox.Items.Add(database);
                }
            }
        }

        public void Connected()
        {
            connectButton.Text = "Disconnect";
            operationGroupBox.Enabled = true;
        }

        public void Disconnected()
        {
            connectButton.Text = "Connect";
            operationGroupBox.Enabled = false;
        }

        public void AddToLog(string message)
        {
            logTextBox.Invoke((MethodInvoker)(() => logTextBox.AppendText(DateTime.Now + @": " + message + "\r\n")));
        }

        public void StartAsyncJob(bool isUsePercent, bool isVisible)
        {
            progressBar.Style = isUsePercent ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
            progressBar.Visible = isVisible;
            connectionGroupBox.Enabled = operationGroupBox.Enabled = !isVisible;
        }

        public void ShowProgressBarPercent(int percent)
        {
            progressBar.Invoke((MethodInvoker)(() =>
            {
                progressBar.Value = percent;
            }));
        }

      
    }
}
