using LabelMaker.ViewModel.Loggers;
using System;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Threading;

namespace LabelMaker
{
    /// <summary>
    /// App.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// A logger that can be used by anyone.
        /// </summary>
        public static ILogger Logger { get; } = new LoggerMessageBox();

        /// <summary>
        /// Constructor.
        /// </summary>
        public App()
        {
            this.Startup += App_Startup;
            this.DispatcherUnhandledException += HandleException;
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        /// <summary>
        /// Error handling.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.FirstChanceException += HandleException;
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        /// <summary>
        /// Error handling.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleException(object sender, FirstChanceExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            HandleException(ex);
        }

        /// <summary>
        /// Error handling.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            HandleException(ex);
        }

        /// <summary>
        /// Error handling.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            HandleException(ex);
            e.Handled = true;
        }

        /// <summary>
        /// Error handling.
        /// </summary>
        /// <param name="e"></param>
        private void HandleException(Exception e)
        {
            Logger.WriteLine(e);
        }
    }
}