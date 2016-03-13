using System;
using System.Windows;
using HardTrainingViewsModel.Logger;

namespace HardTraining.Views.Logger
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
