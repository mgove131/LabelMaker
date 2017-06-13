using LabelMaker.ViewModel.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace LabelMaker.ViewModel
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event Action<string> ShowMessage;

        private int numButtons = 10;

        public MainWindowVm()
        {
            this.labelButtonVms = new List<LabelButtonVm>();
            for (int i = 0; i < numButtons; i++)
            {
                this.labelButtonVms.Add(new LabelButtonVm(this));
            }

            this.selectedButtonIndex = 0;
            this.proNumbersInput = string.Empty;
        }

        private List<LabelButtonVm> labelButtonVms;
        public List<LabelButtonVm> LabelButtonVms
        {
            get { return labelButtonVms; }
        }

        private int selectedButtonIndex;
        public int SelectedButtonIndex
        {
            get { return selectedButtonIndex; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref selectedButtonIndex, value, nameof(SelectedButtonIndex)); }
        }

        private string proNumbersInput;
        public string ProNumbersInput
        {
            get { return proNumbersInput; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref proNumbersInput, value, nameof(ProNumbersInput)); }
        }


        public DateTime Today
        {
            get { return DateTime.Now; }
        }

        private void SendShowMessage(string message)
        {
            ShowMessage?.Invoke(message);
        }

        public void SendShowMessage(string format, params object[] arg)
        {
            SendShowMessage(string.Format(format, arg));
        }

        public void Print()
        {
            var proNums = proNumbersInput?.Split(new[] { ' ', ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();
            foreach (var proNum in proNums)
            {
                Console.WriteLine(proNum);
            }

            int openSpaces = (numButtons - selectedButtonIndex);
            if (proNums.Count > openSpaces)
            {
                SendShowMessage("There are more pro #s ({0}) than labels ({1}), they will be truncated.", proNums.Count, openSpaces);
            }

            //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "LabelMaker.pdf");
            string filePath = Path.Combine("LabelMaker.pdf");
            PdfMaker.PrintLabels(filePath, numButtons, proNums, selectedButtonIndex);
        }
    }
}
