using System.ComponentModel;

namespace LabelMaker.ViewModel.Controls
{
    public class LabelButtonVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LabelButtonVm(MainWindowVm parentVm)
        {
            this.parentVm = parentVm;
        }

        private MainWindowVm parentVm;
        public MainWindowVm ParentVm
        {
            get { return parentVm; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref parentVm, value, nameof(ParentVm)); }
        }
    }
}
