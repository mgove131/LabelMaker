using LabelMaker.ViewModel;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace LabelMaker
{
    public partial class MainWindow : Window
    {
        private MainWindowVm ViewModel { get; } = new MainWindowVm();

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.Loaded += (RoutedEventHandler)((sender, e) =>
            {
                this.Title = string.Format("LabelMaker {0}", (object)Assembly.GetExecutingAssembly().GetName().Version.ToString());
                this.ViewModel.ShowMessage += new Action<string>(this.ShowMessage);
                this.DataContext = (object)this.ViewModel;
            });
        }

        /// <summary>
        /// Display a message.
        /// </summary>
        /// <param name="message">Message</param>
        private void ShowMessage(string message)
        {
            int num = (int)MessageBox.Show((Window)this, message);
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            DoPrint();
        }

        /// <summary>
        /// Call print.
        /// </summary>
        private void DoPrint()
        {
            ViewModel.Print();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// Clear input.
        /// </summary>
        private void Clear()
        {
            ViewModel.Clear();
            uxProNumbers.Items.Refresh();
        }

        /// <summary>
        /// Label the rows by number.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void uxProNumbers_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (object)(e.Row.GetIndex() + 1).ToString();
        }
    }
}