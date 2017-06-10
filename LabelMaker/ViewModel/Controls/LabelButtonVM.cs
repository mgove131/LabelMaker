using System.ComponentModel;

namespace LabelMaker.ViewModel.Controls
{
    public class LabelButtonVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LabelButtonVM()
        {
            this.isSelected = false;
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref isSelected, value, nameof(IsSelected)); }
        }
    }
}
