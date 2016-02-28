using System;
using System.Windows;
using HardTrainingLogger.ViewModel;

namespace HardTrainingLogger.Views
{
    /// <summary>
    /// Interaction logic for LoggerView.xaml
    /// </summary>
    public partial class LoggerView : Window
    {
        public LoggerView()
        {
            InitializeComponent();
        }

        private void BtnLogInClicked(object sender, EventArgs e)
        {
            var mv = this.DataContext as LoggerViewModel;
            mv.ProfilePass = this.pbxPassword.Password;
        }
    }
}
