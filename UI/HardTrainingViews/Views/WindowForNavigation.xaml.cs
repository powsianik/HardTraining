using System.Windows;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Enums;
using HardTrainingCore.Messages;

namespace HardTrainingViews.Views
{
    /// <summary>
    /// Interaction logic for WindowForNavigation.xaml
    /// </summary>
    public partial class WindowForNavigation : NavigationWindow
    {
        public WindowForNavigation(short profileId)
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            
            Messenger.Default.Send(new OpenViewMessage(TypesOfViews.CommonViewModule, profileId));
        }

        private void NavigationWindowGotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Application.Current.MainWindow = this;
        }
    }
}
