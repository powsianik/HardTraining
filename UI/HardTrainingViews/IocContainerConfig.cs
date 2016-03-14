using System;
using EntityFrameworkDomain.Models.Context;
using EntityFrameworkDomain.Models.Context.Concrete;
using EntityFrameworkDomain.Models.Logger;
using EntityFrameworkDomain.Repository;
using EntityFrameworkDomain.Repository.Concrete;
using EntityFrameworkDomain.Repository.Concrete.Logger;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingServices.Logger;
using HardTrainingViewsModel.CommonModule;
using HardTrainingViewsModel.Logger;
using Microsoft.Practices.Unity;

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
            this.iocContainer.RegisterType<ILoggerContext, LoggerContext>();
            this.iocContainer.RegisterType<ILoggerRepo, LoggerRepository>(new PerResolveLifetimeManager());

            this.iocContainer.RegisterType<ProfileChecker>();
            this.iocContainer.RegisterType<LoggerViewModel>();

            this.iocContainer.RegisterType<ICreate<Profile>, EntityCreator<Profile>>(new InjectionConstructor(new LoggerContext()));
            this.iocContainer.RegisterType<SimpleProfileCreator>();
            this.iocContainer.RegisterType<ProfileManagerViewModel>();

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
