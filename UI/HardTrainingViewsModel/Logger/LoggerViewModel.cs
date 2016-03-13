using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingServices.Logger;

using System.Windows;

namespace HardTrainingViewsModel.Logger
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoggerViewModel : ViewModelBase
    {
        private readonly ProfileChecker profileChecker;
       
        public LoggerViewModel(ProfileChecker profileChecker)
        {
            MessengerInstance.Register<HardTrainingCore.Messages.OpenWindowMessage>(this, this.OpenLoggerView);
            this.profileChecker = profileChecker;

            this.OpenProfileManagerCommand = new RelayCommand(this.OpenProfileManager);
            this.LogOnCommand = new RelayCommand(this.LogOn);
        }

        public ICommand OpenProfileManagerCommand { get; private set; }
        public ICommand LogOnCommand { get; private set; }

        public string ProfileName { get; set; }
        public string ProfilePass { get; set; }

        public string Name => "Logger";

        public void LogOn()
        {
            if (this.profileChecker.IsExistProfile(ProfileName, ProfilePass))
            {
                
            }
        }

        private void OpenLoggerView(HardTrainingCore.Messages.OpenWindowMessage msg)
        {
            
            Type windowType = msg.TypeOfWindowToOpen;
            var window = Activator.CreateInstance(windowType) as Window;

            if (window != null)
            {
                window.DataContext = this;
                window.Show();
            }
            else
            {
                
            }
        }

        private void OpenProfileManager()
        {
            /*
            ProfileManagerView profileManagerView = new ProfileManagerView();
            profileManagerView.Show();*/
        }
    }
}