using EntityFrameworkDomain.Repository.Interfaces.UserDataModule;
using GalaSoft.MvvmLight;
using HardTrainingPoco.POCO.UserDataModule;
using HardTrainingViewsModel.Interfaces;

namespace HardTrainingViewsModel.UserDataModule
{
    public class UserDataViewModel : ViewModelBase, IContainId
    {
        private readonly IUserDataRepo repository;

        public UserDataViewModel(IUserDataRepo repo)
        {
            this.repository = repo;

            this.UserData = repo.GetUserData(this.IdOfProfile);
        }

        public short IdOfProfile { private get; set; }

        public UserData UserData { get; private set; }
    }
}