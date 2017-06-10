using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace LabelMaker.View.Controls
{
    public class LabelButton : ToggleButton
    {
        public LabelButton()
        {
            this.IsThreeState = true;

            this.DataContextChanged += (sender, e) =>
            {
                BindingOperations.ClearAllBindings(this);

                if (DataContext != null)
                {
                    setIsCheckedBinding();
                }
            };
        }

        private void setIsCheckedBinding()
        {
            Binding b = new Binding("IsSelected");
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(this, LabelButton.IsCheckedProperty, b);
        }
    }
}
