using LabelMaker.ViewModel.Loggers;
using System;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Threading;

namespace LabelMaker
{
    public partial class App : Application
    {
        public static ILogger Logger { get; } = new LoggerMessageBox();

        public App()
        {
            this.Startup += App_Startup;
            this.DispatcherUnhandledException += HandleException;
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.FirstChanceException += HandleException;
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        private void HandleException(object sender, FirstChanceExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            HandleException(ex);
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
            e.Handled = true;
        }

        private void HandleException(Exception e)
        {
            Logger.WriteLine(e);
        }
    }
}