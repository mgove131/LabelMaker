using System;

namespace LabelMaker.ViewModel.Loggers
{
    /// <summary>
    /// Simple Console logging.
    /// </summary>
    public class LoggerConsole : AbstractBaseLogger
    {
        public override void Write(string value)
        {
            Console.Write(value);
        }
    }
}
