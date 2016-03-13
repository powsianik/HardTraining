using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingRepository.Models.Logger;
using HardTrainingRepository.Repository;
using HardTrainingRepository.Repository.Interfaces.Logger;
using HardTrainingServiceInterfaces.Logger;


namespace HardTrainingViewsModel.Logger
{
    public class ProfileManagerViewModel : ViewModelBase
    {
        private readonly ILoggerRepo _repo;
        private ObservableCollection<Profile> _profiles;
        private bool _isAssistantVisisble;
        private ICommand _toExecuteCommand;

        public ProfileManagerViewModel(ILoggerRepo repo)
        {

            this._repo = repo;

            this.CreateProfileCommand = new RelayCommand<Profile>(this.CreateProfile);
            this.DeleteProfileCommand = new RelayCommand<Profile>(this.DeleteProfile);
            this.ShowAssistantAndSetActionCommand = new RelayCommand<string>(this.ShowAssistantAndSetSpecificAction);

            this._isAssistantVisisble = false;
        }

        public ICommand ToExecuteCommand
        {
            get { return this._toExecuteCommand; }
            private set { this._toExecuteCommand = value; RaisePropertyChanged();}
        }

        public ICommand ShowAssistantAndSetActionCommand { get; private set; }
        public ICommand CreateProfileCommand { get; private set; }
        public ICommand DeleteProfileCommand { get; private set; }

        public Profile SelectedProfile { get; set; }

        public string ProfileName { get; set; }

        public string ProfilePassword { get; set; }

        public ObservableCollection<Profile> Profiles
        {
            get
            {
                return this._profiles;
            }
            private set
            {
                this._profiles = value;
            }
        }

        public bool IsAssistantVisisble
        {
            get
            {
                return _isAssistantVisisble; 
                
            }
            private set
            {
                _isAssistantVisisble = value; 
                
                RaisePropertyChanged();
            }
        }

        private void CreateProfile(Profile profile)
        {
            Profile newProfile = new Profile()
            {
                CreationDate = DateTime.Now,
                Name = this.ProfileName,
                Password = this.ProfilePassword
            };


            this.Profiles.Add(newProfile);

            this.RaisePropertyChanged(() => Profiles);

            this.IsAssistantVisisble = false;
        }

        private void DeleteProfile(Profile profile)
        {
            if (this.CheckAreProvidedDataAndSelectedDataCorrect())
            {
                this._repo.DeleteProfile(this.SelectedProfile);
                this._repo.SaveChanges();
                this.Profiles.Remove(this.SelectedProfile);

                this.RaisePropertyChanged(() => Profiles);
            }

            this.IsAssistantVisisble = false;
        }

        private void ShowAssistantAndSetSpecificAction(string actionName)
        {
            this.IsAssistantVisisble = true;

            switch (actionName)
            {
                case "Create":
                {
                    this.ToExecuteCommand = new RelayCommand<Profile>(this.CreateProfile);
                    break;
                }

                case "Delete":
                {
                    this.ToExecuteCommand = new RelayCommand<Profile>(this.DeleteProfile);
                    break;
                }

                default:
                {
                    this.ToExecuteCommand = null;
                    break;
                }
            }
        }

        private bool CheckAreProvidedDataAndSelectedDataCorrect()
        {
            if (this.SelectedProfile.Name == this.ProfileName && this.SelectedProfile.Password == this.ProfilePassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
