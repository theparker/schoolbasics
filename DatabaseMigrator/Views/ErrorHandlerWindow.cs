using System;
using System.Windows.Forms;
using DatabaseMigrator.Views;

namespace MigrationTool.Views
{
    public partial class ErrorHandlerWindow : Form, IErrorHandlerWindow
    {
        public event Action OnDebugButtonClick;

        public ErrorHandlerWindow()
        {
            InitializeComponent();
            debugButton.Click += (sende, e) => OnDebugButtonClick();
        }

        
        public string ExceptionDetailText {
            get { return errorTextBox.Text; }
            set { errorTextBox.Text = value; }
        }
        
    }
}
