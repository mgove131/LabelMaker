using System.ComponentModel;

namespace LabelMaker.ViewModel
{
    /// <summary>
    /// Object that holds the fields for the input.
    /// </summary>
    public class OutputObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        public OutputObject()
        {
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(proNumber)
                && string.IsNullOrWhiteSpace(date)
                && string.IsNullOrWhiteSpace(customer)
                && string.IsNullOrWhiteSpace(driver)
                && string.IsNullOrWhiteSpace(notes);
        }

        private string proNumber;
        public string ProNumber
        {
            get { return proNumber; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref proNumber, value, nameof(ProNumber)); }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref date, value, nameof(Date)); }
        }

        private string customer;
        public string Customer
        {
            get { return customer; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref customer, value, nameof(Customer)); }
        }


        private string driver;
        public string Driver
        {
            get { return driver; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref driver, value, nameof(Driver)); }
        }


        private string notes;
        public string Notes
        {
            get { return notes; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref notes, value, nameof(Notes)); }
        }
    }
}
