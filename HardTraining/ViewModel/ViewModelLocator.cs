/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:HardTraining"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Messaging;
using HardTrainingLogger.ViewModel;
using HardTraining.ViewModel.CommonModule;
using HardTrainingCore.Messages;
using HardTrainingLogger.Views;
using HardTrainingRepository.Models.Context;
using HardTrainingRepository.Models.Context.Concret;
using HardTrainingRepository.Repositories;
using HardTrainingRepository.Repositories.Concret;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace HardTraining.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var unityContainer = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            unityContainer.RegisterType<ILoggerContext, LoggerContext>(new PerResolveLifetimeManager());
            unityContainer.RegisterType<ILoggerRepo, LoggerRepository>(new PerResolveLifetimeManager());

            unityContainer.RegisterType<MainViewModel>();
            unityContainer.RegisterType<LoggerViewModel>();
            unityContainer.RegisterType<ProfileManagerViewModel>();
            unityContainer.RegisterType<CommonModuleViewModel>();

            this.OpenFirstWindow();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public LoggerViewModel Logger => ServiceLocator.Current.GetInstance<LoggerViewModel>();

        public ProfileManagerViewModel ProfileManager => ServiceLocator.Current.GetInstance<ProfileManagerViewModel>();

        public CommonModuleViewModel CommonModule => ServiceLocator.Current.GetInstance<CommonModuleViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        public void OpenFirstWindow()
        {
            var logger = this.Logger;
            Messenger.Default.Send<OpenWindowMessage>(new OpenWindowMessage(typeof(LoggerView)));
        }
    }
}