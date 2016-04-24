using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;
using HardTrainingViews.Views.CommonModule;
using HardTrainingViews.Views.Logger;
using HardTrainingViews.VMLocator;
using HardTrainingViewsModel.CommonModule;
using HardTrainingViewsModel.Logger;

namespace HardTrainingViews.Views.LoggerModule
{
    /// <summary>
    /// Interaction logic for LoggerView.xaml
    /// </summary>
    public partial class LoggerView : Window
    {
        public LoggerView()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();

            Messenger.Default.Register<OpenViewMessage>(this, this.OpenView);
        }

        private void BtnLogInClicked(object sender, EventArgs e)
        {
            var mv = this.DataContext as LoggerViewModel;
            mv.ProfilePass = this.pbxPassword.Password;
        }

        private void OpenView(OpenViewMessage msg)
        {
            if (msg.TypeOfViewToOpen == TypesOfViews.ProfileManager)
            {
                var view = new ProfileManagerView();
                view.Show();
            }
            else if (msg.TypeOfViewToOpen == TypesOfViews.NavigationWindow)
            {
                var view = new WindowForNavigation(msg.ProfileId);
               
                view.Show();
                this.Close();
            }
        }
    }
}
