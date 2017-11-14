using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace LabelMaker.ViewModel
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        private const int NUM_BUTTONS = 10;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method that shows messages in the UI.
        /// </summary>
        public event Action<string> ShowMessage;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindowVm()
        {
            this.outputObjects = new List<OutputObject>();
            this.InitOutputObjects();
        }

        private void InitOutputObjects()
        {
            this.outputObjects.Clear();
            for (int index = 0; index < NUM_BUTTONS; ++index)
                this.outputObjects.Add(new OutputObject());
        }

        private List<OutputObject> outputObjects;
        /// <summary>
        /// Input objects.
        /// </summary>
        public List<OutputObject> OutputObjects
        {
            get { return outputObjects; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref outputObjects, value, nameof(OutputObjects)); }
        }

        /// <summary>
        /// Show a message in the UI.
        /// </summary>
        /// <param name="message">message</param>
        private void SendShowMessage(string message)
        {
            ShowMessage?.Invoke(message);
        }

        /// <summary>
        /// Show a message in the UI.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An object array that contains zero or more objects to format</param>
        public void SendShowMessage(string format, params object[] arg)
        {
            SendShowMessage(string.Format(format, arg));
        }

        /// <summary>
        /// Create PDF output.
        /// </summary>
        public void Print()
        {
            PdfMaker.PrintLabels(Path.Combine("LabelMaker.pdf"), outputObjects, true);
        }

        /// <summary>
        /// Clear input.
        /// </summary>
        public void Clear()
        {
            InitOutputObjects();
        }
    }
}
