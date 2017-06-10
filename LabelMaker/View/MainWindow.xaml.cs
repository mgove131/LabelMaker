using LabelMaker.View.Controls;
using LabelMaker.ViewModel;
using System;
using System.Windows;

namespace LabelMaker
{
    public partial class MainWindow : Window
    {
        private MainWindowVm ViewModel { get; } = new MainWindowVm();

        public MainWindow()
        {
            InitializeComponent();

            this.Initialized += (sender, e) =>
            {
                try
                {
                    InitalizedMethod(sender, e);
                }
                catch (Exception ex)
                {
                    App.Logger.WriteLine(ex);
                }
            };

            this.Loaded += (sender, e) =>
            {
                try
                {
                    LoadedMethod(sender, e);
                }
                catch (Exception ex)
                {
                    App.Logger.WriteLine(ex);
                }
            };
        }

        private void InitalizedMethod(object sender, EventArgs e)
        {

        }

        private void LoadedMethod(object sender, RoutedEventArgs e)
        {
            int buttonIndex = 0;
            foreach (var labelButtonVm in ViewModel.LabelButtonVms)
            {
                var button = new LabelButton();
                button.ButtonIndex = buttonIndex;
                button.Content = string.Format("{0}", buttonIndex + 1);
                button.DataContext = labelButtonVm;
                uxButtonGrid.Children.Add(button);

                buttonIndex++;
            }

            this.DataContext = ViewModel;
        }
    }
}
