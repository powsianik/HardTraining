using System.Windows;
using System.Windows.Controls;

namespace HardTrainingViews.Views.PlanModule.PlanCreator.UserConrols
{
    /// <summary>
    /// Interaction logic for DayToSelect.xaml
    /// </summary>
    public partial class DayToSelect : UserControl
    {
        public DayToSelect()
        {
            InitializeComponent();

            this.DataContext = this;        
        }

        public static readonly DependencyProperty DayLabelProperty = DependencyProperty.Register("DayLabel",
            typeof (string), typeof(DayToSelect), new PropertyMetadata(""));

        public static readonly DependencyProperty DayCheckedProperty = DependencyProperty.Register("DayChecked",
            typeof(bool), typeof(DayToSelect), new PropertyMetadata(default(bool)));

        public string DayLabel
        {
            get { return (string) this.GetValue(DayLabelProperty); }
            set
            {
                this.SetValue(DayLabelProperty, value);
            }
        }

        public bool DayChecked
        {
            get { return (bool)this.GetValue(DayCheckedProperty); }
            set
            {
                this.SetValue(DayCheckedProperty, value);
            }
        }
    }
}
