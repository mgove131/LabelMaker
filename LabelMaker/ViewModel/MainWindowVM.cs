using LabelMaker.ViewModel.Controls;
using System.Collections.Generic;
using System.ComponentModel;

namespace LabelMaker.ViewModel
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVm()
        {
            this.labelButtonVms = new List<LabelButtonVm>
            {
                new LabelButtonVm(this),
                new LabelButtonVm(this),
                new LabelButtonVm(this),
                new LabelButtonVm(this),
                new LabelButtonVm(this),
                new LabelButtonVm(this),
            };

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
    }
}
