using System;

namespace LabelMaker.ViewModel.Loggers
{
    /// <summary>
    /// Interface for writing out strings.
    /// Allows for multiple methods, and easy switching.
    /// </summary>
    public interface ILogger
    {
        void Write(string value);
        void Write(string format, params object[] arg);
        void Write(Exception ex);
        void WriteLine(string value);
        void WriteLine(string format, params object[] arg);
        void WriteLine(Exception ex);
    }
}
