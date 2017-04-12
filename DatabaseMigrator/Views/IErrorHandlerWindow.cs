using System;

namespace DatabaseMigrator.Views
{
	public interface IErrorHandlerWindow
	{

		event Action OnDebugButtonClick;
		string ExceptionDetailText { get; set; }
		void Show();
	}
}
