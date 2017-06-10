using System;

namespace LabelMaker.ViewModel.Loggers
{
    /// <summary>
    /// No need to always implement all the wrapper methods.
    /// We only really need to implement Write(string value).
    /// </summary>
    public abstract class AbstractBaseLogger : ILogger
    {
        public abstract void Write(string value);

        public void Write(string format, params object[] arg)
        {
            Write(String.Format(format, arg));
        }

        public void Write(Exception ex)
        {
            Write(ex.ToString());
        }

        public void WriteLine(string value)
        {
            Write(String.Format("{0}{1}", value, Environment.NewLine));
        }

        public void WriteLine(string format, params object[] arg)
        {
            WriteLine(String.Format(format, arg));
        }

        public void WriteLine(Exception ex)
        {
            WriteLine(ex.ToString());
        }
    }
}
