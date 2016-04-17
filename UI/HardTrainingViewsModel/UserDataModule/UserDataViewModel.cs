using System;
using System.Windows.Input;
using EntityFrameworkDomain.Repository.Interfaces.UserDataModule;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingCore.Messages;
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

            this.Init();
        }

        public ICommand OpenUserDataSetterCommand { get; private set; }

        public ICommand SaveUserDataCommand { get; private set; }

        public bool IsUserDataNotExist { get; private set; }

        public short IdOfProfile { private get; set; }

        public UserData UserData { get; private set; }

        private void Init()
        {
            this.UserData = repository.GetUserData(this.IdOfProfile);

            if (this.UserData == null)
            {
                this.IsUserDataNotExist = true;
                this.UserData = new UserData();
            }

            this.OpenUserDataSetterCommand = new RelayCommand(this.OpenDataSetter);
            this.SaveUserDataCommand = new RelayCommand(this.SaveUserData);
        }

        private void OpenDataSetter()
        {
            MessengerInstance.Send(new OpenViewMessage(TypesOfViews.UserDataSetter, this.IdOfProfile));
        }

        private void SaveUserData()
        {
            this.UserData.MeasureDate = DateTime.Now;
            this.UserData.ProfileId = this.IdOfProfile;

            this.repository.SaveUserData(this.UserData);
            this.repository.SaveChanges();
        }
    }
}