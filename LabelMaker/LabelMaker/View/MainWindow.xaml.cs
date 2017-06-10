using LabelMaker.ViewModel;
using System.Windows;

namespace LabelMaker
{
    public partial class MainWindow : Window
    {
        private MainWindowVM ViewModel { get; } = new MainWindowVM();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModel;
        }
    }
}
