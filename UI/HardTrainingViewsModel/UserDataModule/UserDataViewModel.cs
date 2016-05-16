using System;
using System.Runtime.CompilerServices;
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
        private short idOfProfile;
        private UserData userData;
        private readonly IUserDataRepo repository;

        public UserDataViewModel(IUserDataRepo repo)
        {
            this.repository = repo;

            this.OpenUserDataSetterCommand = new RelayCommand(this.OpenDataSetter);
            this.OpenAnalyserInTimeCommand = new RelayCommand(this.OpenAnalyserInTime);
            this.SaveUserDataCommand = new RelayCommand(this.SaveUserData);
        }

        public ICommand OpenUserDataSetterCommand { get; private set; }

        public ICommand OpenAnalyserInTimeCommand { get; private set; }

        public ICommand SaveUserDataCommand { get; private set; }

        public bool IsUserDataNotExist { get; private set; }

        public short IdOfProfile
        {
            private get { return this.idOfProfile; }
            set
            {
                this.idOfProfile = value;
                this.UserData = repository.GetUserData(this.IdOfProfile);

                if (this.UserData == null)
                {
                    this.IsUserDataNotExist = true;
                    this.UserData = new UserData();
                }
            }
        }

        public UserData UserData
        {
            get { return this.userData; }
            set
            {
                this.userData = value;
                this.RaisePropertyChanged();
            }
        }

        private void OpenDataSetter()
        {
            MessengerInstance.Send(new OpenViewMessage(TypesOfViews.UserDataSetter, this.IdOfProfile));
        }

        private void OpenAnalyserInTime()
        {
            MessengerInstance.Send(new OpenViewMessage(TypesOfViews.AnalyserOfUserDataInTime, this.IdOfProfile));
        }

        private void SaveUserData()
        {
            this.UserData.MeasureDate = DateTime.Now;
            this.UserData.ProfileId = this.IdOfProfile;

            this.repository.SaveUserData(this.UserData);
            this.repository.SaveChanges();

            MessengerInstance.Send(new BackToRecentViewMessage());
        }
    }
}