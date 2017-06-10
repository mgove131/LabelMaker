using System.Windows;

namespace LabelMaker.ViewModel.Loggers
{
    /// <summary>
    /// Show message in a MessageBox.
    /// </summary>
    public class LoggerMessageBox : AbstractBaseLogger
    {
        public override void Write(string value)
        {
            MessageBox.Show(value);
        }
    }
}
