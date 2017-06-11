using LabelMaker.View.Controls;
using LabelMaker.ViewModel;
using System.Windows;

namespace LabelMaker
{
    public partial class MainWindow : Window
    {
        private MainWindowVm ViewModel { get; } = new MainWindowVm();

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
            {
                ViewModel.ShowMessage += ShowMessage;

                int buttonIndex = 0;
                foreach (var labelButtonVm in ViewModel.LabelButtonVms)
                {
                    var button = new LabelButton()
                    {
                        ButtonIndex = buttonIndex,
                        Content = string.Format("{0}", buttonIndex + 1),
                        DataContext = labelButtonVm,
                    };
                    uxButtonGrid.Children.Add(button);

                    buttonIndex++;
                }

                this.DataContext = ViewModel;
            };
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(this, message);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            DoPrint();
        }

        private void DoPrint()
        {
            ViewModel.Print();
        }
    }
}
