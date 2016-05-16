using System;
using System.Data.Entity;
using EntityFrameworkDomain.Context.Concrete;
using EntityFrameworkDomain.Context.Interfaces;
using EntityFrameworkDomain.Repository;
using EntityFrameworkDomain.Repository.Concrete;
using EntityFrameworkDomain.Repository.Concrete.Logger;
using EntityFrameworkDomain.Repository.Concrete.UserDataModule;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using EntityFrameworkDomain.Repository.Interfaces.UserDataModule;
using HardTrainingPoco.POCO.Logger;
using HardTrainingServices.Logger;
using HardTrainingViews.Navigation;
using HardTrainingViewsModel.AnalyserModule;
using HardTrainingViewsModel.CommonModule;
using HardTrainingViewsModel.Logger;
using HardTrainingViewsModel.UserDataModule;
using Microsoft.Practices.Unity;
using NLog;

namespace HardTrainingViews
{
    internal class IocContainerConfig : IDisposable
    {
        private readonly IUnityContainer iocContainer;

        public IocContainerConfig()
        {
            this.iocContainer = new UnityContainer();
        }

        private void Register()
        {
            this.iocContainer.RegisterType<ISimpleNavigationService, NavigationService>
               (new ContainerControlledLifetimeManager());

            this.iocContainer.RegisterType<HardTrainingMainContext>(new ContainerControlledLifetimeManager());
            this.iocContainer.RegisterType<DbContext, HardTrainingMainContext>();
            this.iocContainer.RegisterType<IHardTrainingContext, HardTrainingMainContext>();

            this.iocContainer.RegisterType<ILoggerRepo, LoggerRepository>();
            this.iocContainer.RegisterType<IUserDataRepo, UserDataRepository>();

            this.iocContainer.RegisterType<IReadAll<Profile>, EntityReader<Profile>>();
            this.iocContainer.RegisterType<ProfileChecker>();
            this.iocContainer.RegisterType<LoggerViewModel>();

            this.iocContainer.RegisterType<ICreate<Profile>, EntityCreator<Profile>>();
            this.iocContainer.RegisterType<SimpleProfileCreator>();
            this.iocContainer.RegisterType<IDelete<Profile>, EntityDeleter<Profile>>();
            this.iocContainer.RegisterType<SimpleProfileDeleter>();
            this.iocContainer.RegisterType<ProfileManagerViewModel>();

            this.iocContainer.RegisterType<UserDataViewModel>(new ContainerControlledLifetimeManager());

            this.iocContainer.RegisterType<DataAnalyserViewModel>();

            this.iocContainer.RegisterType<CommonModuleViewModel>();
        }

        public IUnityContainer GetPreparingContainer()
        {
            this.Register();

            return this.iocContainer;
        }

        public void Dispose()
        {
            this.iocContainer.Dispose();
        }
    }
}
