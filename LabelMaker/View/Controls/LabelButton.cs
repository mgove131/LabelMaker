using LabelMaker.ViewModel.Controls;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace LabelMaker.View.Controls
{
    public class LabelButton : Button
    {
        public int ButtonIndex
        {
            get { return (int)GetValue(ButtonIndexProperty); }
            set { SetValue(ButtonIndexProperty, value); }
        }
        public static readonly DependencyProperty ButtonIndexProperty =
            DependencyProperty.Register("ButtonIndex", typeof(int), typeof(LabelButton), new PropertyMetadata(0, (d, e) =>
            {
                ((LabelButton)d).UpdateBindings();
            }));

        private LabelButtonVm vm;

        private Binding buttonBinding;

        private LabelButtonConverter converter;

        public LabelButton()
        {
            this.buttonBinding = null;
            this.converter = new LabelButtonConverter();

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
            this.DataContextChanged += (sender1, e1) =>
            {
                UpdateBindings();
            };

            this.Click += (sender1, e1) =>
            {
                ButtonClick();
            };
        }

        private void LoadedMethod(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateBindings()
        {
            BindingOperations.ClearAllBindings(this);
            buttonBinding = null;

            if (DataContext != null)
            {
                vm = (LabelButtonVm)DataContext;

                buttonBinding = new Binding("SelectedButtonIndex");
                buttonBinding.Source = vm.ParentVm;
                buttonBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                buttonBinding.ConverterParameter = ButtonIndex;
                buttonBinding.Converter = converter;
                BindingOperations.SetBinding(this, LabelButton.ForegroundProperty, buttonBinding);
            }
        }

        private void ButtonClick()
        {
            if (vm != null)
            {
                vm.ParentVm.SelectedButtonIndex = ButtonIndex;
            }
        }
    }

    class LabelButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int selectedIndex = Int32.Parse(value.ToString());
            int buttonIndex = Int32.Parse(parameter.ToString());

            return (buttonIndex <= selectedIndex)
                ? Brushes.Red
                : Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
