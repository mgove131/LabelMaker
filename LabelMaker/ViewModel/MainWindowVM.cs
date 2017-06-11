﻿using LabelMaker.ViewModel.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LabelMaker.ViewModel
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int numButtons = 10;

        public MainWindowVm()
        {
            this.labelButtonVms = new List<LabelButtonVm>();
            for (int i = 0; i < numButtons; i++)
            {
                this.labelButtonVms.Add(new LabelButtonVm(this));
            }

            this.selectedButtonIndex = 0;
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

        public void Print()
        {
            string[] proNumbers = proNumbersInput.Split(new[] { ' ', ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var proNumber in proNumbers)
            {
                Console.WriteLine(proNumber);
            }
        }
    }
}
