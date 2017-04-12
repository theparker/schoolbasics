namespace DatabaseMigrator.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.useIntegratedLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passwdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hostNameTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.migrationNamespaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operationGroupBox = new System.Windows.Forms.GroupBox();
            this.finishButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newDBNameTextBox = new System.Windows.Forms.TextBox();
            this.ExistDBComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backupRadioButton = new System.Windows.Forms.RadioButton();
            this.restoreRadioButton = new System.Windows.Forms.RadioButton();
            this.createDBRadioButton = new System.Windows.Forms.RadioButton();
            this.updateDBRadioButton = new System.Windows.Forms.RadioButton();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.connectionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.migrationNamespaceBindingSource)).BeginInit();
            this.operationGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Controls.Add(this.connectButton);
            this.connectionGroupBox.Controls.Add(this.useIntegratedLoginCheckBox);
            this.connectionGroupBox.Controls.Add(this.label3);
            this.connectionGroupBox.Controls.Add(this.passwdTextBox);
            this.connectionGroupBox.Controls.Add(this.label2);
            this.connectionGroupBox.Controls.Add(this.loginTextBox);
            this.connectionGroupBox.Controls.Add(this.label1);
            this.connectionGroupBox.Controls.Add(this.hostNameTextBox);
            this.connectionGroupBox.Location = new System.Drawing.Point(9, 13);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(319, 166);
            this.connectionGroupBox.TabIndex = 0;
            this.connectionGroupBox.TabStop = false;
            this.connectionGroupBox.Text = "Connection to MSSQL Server";
            // 
            // connectButton
            // 
            this.connectButton.Image = global::DatabaseMigrator.Properties.Resources.Connect;
            this.connectButton.Location = new System.Drawing.Point(161, 126);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(152, 32);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.connectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // useIntegratedLoginCheckBox
            // 
            this.useIntegratedLoginCheckBox.AutoSize = true;
            this.useIntegratedLoginCheckBox.Location = new System.Drawing.Point(101, 45);
            this.useIntegratedLoginCheckBox.Name = "useIntegratedLoginCheckBox";
            this.useIntegratedLoginCheckBox.Size = new System.Drawing.Size(121, 17);
            this.useIntegratedLoginCheckBox.TabIndex = 1;
            this.useIntegratedLoginCheckBox.Text = "Use Integrated login";
            this.useIntegratedLoginCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "User Pass:";
            // 
            // passwdTextBox
            // 
            this.passwdTextBox.Location = new System.Drawing.Point(101, 94);
            this.passwdTextBox.Name = "passwdTextBox";
            this.passwdTextBox.Size = new System.Drawing.Size(212, 20);
            this.passwdTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Login:";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(101, 68);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(212, 20);
            this.loginTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host:";
            // 
            // hostNameTextBox
            // 
            this.hostNameTextBox.Location = new System.Drawing.Point(101, 19);
            this.hostNameTextBox.Name = "hostNameTextBox";
            this.hostNameTextBox.Size = new System.Drawing.Size(212, 20);
            this.hostNameTextBox.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.migrationNamespaceBindingSource;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // migrationNamespaceBindingSource
            // 
            this.migrationNamespaceBindingSource.DataSource = typeof(DatabaseMigrator.Dtos.MigrationNamespace);
            // 
            // operationGroupBox
            // 
            this.operationGroupBox.Controls.Add(this.finishButton);
            this.operationGroupBox.Controls.Add(this.refreshButton);
            this.operationGroupBox.Controls.Add(this.label5);
            this.operationGroupBox.Controls.Add(this.label4);
            this.operationGroupBox.Controls.Add(this.newDBNameTextBox);
            this.operationGroupBox.Controls.Add(this.ExistDBComboBox);
            this.operationGroupBox.Controls.Add(this.groupBox4);
            this.operationGroupBox.Controls.Add(this.groupBox3);
            this.operationGroupBox.Location = new System.Drawing.Point(8, 217);
            this.operationGroupBox.Name = "operationGroupBox";
            this.operationGroupBox.Size = new System.Drawing.Size(319, 308);
            this.operationGroupBox.TabIndex = 1;
            this.operationGroupBox.TabStop = false;
            // 
            // finishButton
            // 
            this.finishButton.Image = global::DatabaseMigrator.Properties.Resources.Finish;
            this.finishButton.Location = new System.Drawing.Point(157, 262);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(152, 32);
            this.finishButton.TabIndex = 12;
            this.finishButton.Text = "Do Job";
            this.finishButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finishButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.finishButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Image = global::DatabaseMigrator.Properties.Resources.Refresh;
            this.refreshButton.Location = new System.Drawing.Point(278, 200);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(30, 23);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "New Database Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Select Database:";
            // 
            // newDBNameTextBox
            // 
            this.newDBNameTextBox.Location = new System.Drawing.Point(124, 228);
            this.newDBNameTextBox.Name = "newDBNameTextBox";
            this.newDBNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.newDBNameTextBox.TabIndex = 11;
            // 
            // ExistDBComboBox
            // 
            this.ExistDBComboBox.FormattingEnabled = true;
            this.ExistDBComboBox.Location = new System.Drawing.Point(124, 201);
            this.ExistDBComboBox.Name = "ExistDBComboBox";
            this.ExistDBComboBox.Size = new System.Drawing.Size(148, 21);
            this.ExistDBComboBox.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Location = new System.Drawing.Point(6, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 49);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Migration Namespace";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.backupRadioButton);
            this.groupBox3.Controls.Add(this.restoreRadioButton);
            this.groupBox3.Controls.Add(this.createDBRadioButton);
            this.groupBox3.Controls.Add(this.updateDBRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(9, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 113);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operation Type";
            // 
            // backupRadioButton
            // 
            this.backupRadioButton.AutoSize = true;
            this.backupRadioButton.Location = new System.Drawing.Point(6, 88);
            this.backupRadioButton.Name = "backupRadioButton";
            this.backupRadioButton.Size = new System.Drawing.Size(163, 17);
            this.backupRadioButton.TabIndex = 8;
            this.backupRadioButton.TabStop = true;
            this.backupRadioButton.Text = "Backup To Local Backup file";
            this.backupRadioButton.UseVisualStyleBackColor = true;
            // 
            // restoreRadioButton
            // 
            this.restoreRadioButton.AutoSize = true;
            this.restoreRadioButton.Location = new System.Drawing.Point(6, 65);
            this.restoreRadioButton.Name = "restoreRadioButton";
            this.restoreRadioButton.Size = new System.Drawing.Size(173, 17);
            this.restoreRadioButton.TabIndex = 7;
            this.restoreRadioButton.TabStop = true;
            this.restoreRadioButton.Text = "Restore From Local Backup file";
            this.restoreRadioButton.UseVisualStyleBackColor = true;
            // 
            // createDBRadioButton
            // 
            this.createDBRadioButton.AutoSize = true;
            this.createDBRadioButton.Location = new System.Drawing.Point(6, 19);
            this.createDBRadioButton.Name = "createDBRadioButton";
            this.createDBRadioButton.Size = new System.Drawing.Size(241, 17);
            this.createDBRadioButton.TabIndex = 5;
            this.createDBRadioButton.TabStop = true;
            this.createDBRadioButton.Text = "Create New Database From Local Backup file";
            this.createDBRadioButton.UseVisualStyleBackColor = true;
            // 
            // updateDBRadioButton
            // 
            this.updateDBRadioButton.AutoSize = true;
            this.updateDBRadioButton.Location = new System.Drawing.Point(6, 42);
            this.updateDBRadioButton.Name = "updateDBRadioButton";
            this.updateDBRadioButton.Size = new System.Drawing.Size(146, 17);
            this.updateDBRadioButton.TabIndex = 6;
            this.updateDBRadioButton.TabStop = true;
            this.updateDBRadioButton.Text = "Update To Latest Version";
            this.updateDBRadioButton.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(338, 25);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(434, 507);
            this.logTextBox.TabIndex = 13;
            this.logTextBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Log:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 182);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(319, 36);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 537);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.operationGroupBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.connectionGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 575);
            this.Name = "MainForm";
            this.Text = "C# Database Migrator";
            this.connectionGroupBox.ResumeLayout(false);
            this.connectionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.migrationNamespaceBindingSource)).EndInit();
            this.operationGroupBox.ResumeLayout(false);
            this.operationGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.CheckBox useIntegratedLoginCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostNameTextBox;
        private System.Windows.Forms.GroupBox operationGroupBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton createDBRadioButton;
        private System.Windows.Forms.RadioButton updateDBRadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newDBNameTextBox;
        private System.Windows.Forms.ComboBox ExistDBComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.RadioButton backupRadioButton;
        private System.Windows.Forms.RadioButton restoreRadioButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource migrationNamespaceBindingSource;
    }
}

