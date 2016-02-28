using System.Windows;
using System.Windows.Input;

namespace HardTrainingLogger.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProfileOperationsAssistant.xaml
    /// </summary>
    public partial class ProfileOperationsAssistant
    {
        public static DependencyProperty CommandWhenConfirmProperty = DependencyProperty.Register("CommandWhenConfirm", typeof (ICommand),typeof (ProfileOperationsAssistant));

        public ProfileOperationsAssistant()
        {
            InitializeComponent();
        }

        public ProfileOperationsAssistant(bool isUnitTest = false)
        {
            if (!isUnitTest)
            {
                InitializeComponent();
            }
        }

        public ICommand CommandWhenConfirm
        {
            get { return (ICommand)this.GetValue(CommandWhenConfirmProperty); }
            set
            {
                this.SetValue(CommandWhenConfirmProperty, value);
            }
        }

        public void BtnConfirmClicked(object seder, RoutedEventArgs re)
        {
            if (this.tbxName.Text.Length < 3 || this.tbxPassword.Text.Length < 5)
            {
                this.lblWarning.Content = "Nazwa musi mieć co najmniej 3 znaki, a hasło co najmniej 5.";
                this.lblWarning.Visibility = Visibility.Visible;
            }
            else
            {
                this.CommandWhenConfirm.Execute(null);
            }
        }
    }
}
