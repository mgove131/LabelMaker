using LabelMaker.ViewModel.Loggers;
using System;
using System.Windows;
using System.Windows.Threading;

namespace LabelMaker
{
    public partial class App : Application
    {
        public static ILogger Logger { get; } = new LoggerMessageBox();

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += HandleException;
            this.DispatcherUnhandledException += HandleException;
        }

        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            HandleException(ex);
        }

        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            HandleException(ex);
        }

        private void HandleException(Exception e)
        {
            Logger.WriteLine(e);
        }
    }
}