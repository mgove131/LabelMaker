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
            Write(string.Format(format, arg));
        }

        public void Write(Exception ex)
        {
            if (ex != null)
            {
                Write(ex.ToString());
            }
        }

        public void WriteLine(string value)
        {
            Write(string.Format("{0}{1}", value, Environment.NewLine));
        }

        public void WriteLine(string format, params object[] arg)
        {
            WriteLine(string.Format(format, arg));
        }

        public void WriteLine(Exception ex)
        {
            if (ex != null)
            {
                WriteLine(ex.ToString());
            }
        }
    }
}
