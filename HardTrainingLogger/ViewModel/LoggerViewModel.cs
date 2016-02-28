using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingCore.Messages;
using HardTrainingLogger.Views;
using HardTrainingRepository.Repositories;

namespace HardTrainingLogger.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoggerViewModel : ViewModelBase
    {
        private readonly ILoggerRepo _repo;
       
        public LoggerViewModel(ILoggerRepo repo)
        {
            MessengerInstance.Register<OpenWindowMessage>(this, this.OpenLoggerView);
            this._repo = repo;

            this.OpenProfileManagerCommand = new RelayCommand(this.OpenProfileManager);
            this.LogOnCommand = new RelayCommand(this.LogOns);
        }

        public ICommand OpenProfileManagerCommand { get; private set; }
        public ICommand LogOnCommand { get; private set; }

        public string Name => "Logger";


        public void LogOns()
        {

            //return this._repo.IsExistProfile(login, password);
        }

        public bool LogOn(string s, string v)
        {
            return this._repo.IsExistProfile(s, v);
        }

        private void OpenLoggerView(OpenWindowMessage msg)
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
            ProfileManagerView profileManagerView = new ProfileManagerView();
            profileManagerView.Show();
        }
    }
}