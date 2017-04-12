#region usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DatabaseMigrator.Components;
using DatabaseMigrator.Conrollers;
using DatabaseMigrator.Dtos;

#endregion

namespace DatabaseMigrator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => HandleError((Exception)e.ExceptionObject);
            Application.ThreadException += (sender, e) => HandleError(e.Exception);

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainController = new MainController();
            Application.Run(mainController.Run());
        }


        private static void HandleError(Exception exception)
        {
            try
            {
                if (exception.Message.ToLower().Contains("timeout"))
                {
                    MessageBox.Show("Проблема с сетевым доступом к серверу базы данных! \n (Connection Timeout)", "ошибка...",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                new ErrorHandlerController(exception).Run();
            }
            catch (Exception e)
            {

                MessageBox.Show("Ошибка обработки ошибки: \n \n" + e);
                if (MessageBox.Show("Подключить отладчик? \n Для разработчика!!!", "Отладка...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Debugger.Launch();
                    throw;
                }
            }

        }
    }
}
