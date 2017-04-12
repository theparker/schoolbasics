using System;
using System.Diagnostics;
using System.Windows.Forms;
using DatabaseMigrator.Views;
using MigrationTool.Views;

namespace DatabaseMigrator.Conrollers
{
	public class ErrorHandlerController
	{
		private readonly Exception _exception;
		private readonly IErrorHandlerWindow _view = new ErrorHandlerWindow();


		public ErrorHandlerController(Exception exception)
		{
			_exception = exception;
			SubscribeEvents();
		}

		private void SubscribeEvents()
		{
			_view.OnDebugButtonClick += View_OnDebugButtonClick;
		}

		private void View_OnDebugButtonClick()
		{
			if (MessageBox.Show("Attach a debugger?? \n For developer!!!", "Debugging...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Debugger.Launch();
				throw _exception;
			}
		}

		public void Run()
		{
			_view.Show();

			string exceptionInfoText = string.Format(
				"An unexpected error occurred: {0}" + Environment.NewLine +
				"Time: {1} " + Environment.NewLine +
				"{2}" + Environment.NewLine +
				"InnerException: \n {3}" + Environment.NewLine +
				"InnerException StackTrace: \n  {4}" + Environment.NewLine,
				_exception.Message,
				DateTime.Now,
				_exception,
				_exception.InnerException,
				_exception.InnerException != null
					? _exception.InnerException.StackTrace
					: string.Empty
			);

			_view.ExceptionDetailText = exceptionInfoText;

		}


	}
}
