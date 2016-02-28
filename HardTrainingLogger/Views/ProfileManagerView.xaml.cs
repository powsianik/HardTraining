using System.Windows;

namespace HardTrainingLogger.Views
{
    /// <summary>
    /// Interaction logic for ProfileManagerView.xaml
    /// </summary>
    public partial class ProfileManagerView : Window
    {
        public ProfileManagerView()
        {
            InitializeComponent();
        }

        public void LvProfilesSelectionChanged(object sender, RoutedEventArgs re)
        {
            this.SetVisiblity();
        }

        private void SetVisiblity()
        {
            if (this.LvProfiles.SelectedIndex == -1)
            {
                this.BtnDeleteProfile.Visibility = Visibility.Hidden;
            }
            else
            {
                this.BtnDeleteProfile.Visibility = Visibility.Visible;
            }
        }
    }
}
