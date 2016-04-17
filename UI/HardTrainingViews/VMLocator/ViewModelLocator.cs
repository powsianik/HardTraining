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
using HardTrainingViewsModel.CommonModule;
using HardTrainingViewsModel.Logger;
using HardTrainingViewsModel.UserDataModule;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace HardTrainingViews.VMLocator
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
        }

        public LoggerViewModel Logger => ServiceLocator.Current.GetInstance<LoggerViewModel>();

        public ProfileManagerViewModel ProfileManager => ServiceLocator.Current.GetInstance<ProfileManagerViewModel>();

        public CommonModuleViewModel CommonModule => ServiceLocator.Current.GetInstance<CommonModuleViewModel>();

        public UserDataViewModel UserDataModule => ServiceLocator.Current.GetInstance<UserDataViewModel>(); 

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
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