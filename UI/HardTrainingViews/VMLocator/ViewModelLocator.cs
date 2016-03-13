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

using System;
using GalaSoft.MvvmLight.Messaging;
using HardTraining.Views.Logger;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.CommonModule;
using HardTrainingViewsModel.Logger;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace HardTraining.VMLocator
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator : IDisposable
    {
        private readonly IocContainerConfig iocConfig;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            this.iocConfig = new IocContainerConfig();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(this.iocConfig.GetPreparingContainer()));

            this.OpenFirstWindow();
        }

        public LoggerViewModel Logger => ServiceLocator.Current.GetInstance<LoggerViewModel>();

        public ProfileManagerViewModel ProfileManager => ServiceLocator.Current.GetInstance<ProfileManagerViewModel>();

        public CommonModuleViewModel CommonModule => ServiceLocator.Current.GetInstance<CommonModuleViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private void OpenFirstWindow()
        {   
            NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
            log.Trace("OpenFirstWindow was called.");

            var logger = this.Logger;
            Messenger.Default.Send<OpenWindowMessage>(new OpenWindowMessage(typeof(LoggerView)));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                this.iocConfig.Dispose();
            }
        }
    }
}