using System.Collections.ObjectModel;
using System.Windows.Input;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingPoco.POCO.Logger;
using HardTrainingServices.Logger;

namespace HardTrainingViewsModel.Logger
{
    public class ProfileManagerViewModel : ViewModelBase
    {
        private  ILoggerRepo _repo;
        private readonly SimpleProfileCreator profileCreator;
        private readonly SimpleProfileDeleter profileDeleter;
        private ObservableCollection<Profile> profiles;
        private bool isAssistantVisisble;
        private ICommand toExecuteCommand;

        public ProfileManagerViewModel(ILoggerRepo repo, SimpleProfileCreator profileCreator, SimpleProfileDeleter profileDeleter)
        {
            this._repo = repo;
            this.profileCreator = profileCreator;
            this.profileDeleter = profileDeleter;
            this.profiles = new ObservableCollection<Profile>(this._repo.GetProfiles());

            this.CreateProfileCommand = new RelayCommand(this.CreateProfile);
            this.DeleteProfileCommand = new RelayCommand<Profile>(this.DeleteProfile);
            this.ShowAssistantAndSetActionCommand = new RelayCommand<string>(this.ShowAssistantAndSetSpecificAction);

            this.isAssistantVisisble = false;
        }

        public ICommand ToExecuteCommand
        {
            get { return this.toExecuteCommand; }
            private set { this.toExecuteCommand = value; RaisePropertyChanged();}
        }

        public ICommand ShowAssistantAndSetActionCommand { get; private set; }
        public ICommand CreateProfileCommand { get; private set; }
        public ICommand DeleteProfileCommand { get; private set; }

        private Profile SelectedProfile { get; set; }

        public string ProfileName { get; set; }

        public string ProfilePassword { get; set; }

        public ObservableCollection<Profile> Profiles
        {
            get
            {
                return this.profiles;
            }
            private set
            {
                this.profiles = value;
            }
        }

        public bool IsAssistantVisisble
        {
            get
            {
                return isAssistantVisisble; 
                
            }
            private set
            {
                isAssistantVisisble = value; 
                
                RaisePropertyChanged();
            }
        }

        private void CreateProfile()
        {
            this.profileCreator.CreateProfile(this.ProfileName, this.ProfilePassword);
            /*
            Profile newProfile = new Profile()
            {
                CreationDate = DateTime.Now,
                Name = this.ProfileName,
                Password = this.ProfilePassword
            };
            */
            //this._repo.AddProfile(newProfile);
            //this._repo.SaveChanges();

            //this.Profiles.Add(newProfile);

            this.RaisePropertyChanged(() => Profiles);     
            this.IsAssistantVisisble = false;
        }

        private void DeleteProfile(Profile profile)
        {
            if (this.CheckAreProvidedDataAndSelectedDataCorrect())
            {
                this.profileDeleter.Delete(this.SelectedProfile.Name, this.SelectedProfile.Password);
                //this._repo.DeleteProfile(this.SelectedProfile);
                //this._repo.SaveChanges();
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
                    this.ToExecuteCommand = new RelayCommand(this.CreateProfile);
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