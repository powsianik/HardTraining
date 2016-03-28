using GalaSoft.MvvmLight;
using HardTrainingPoco.Models.UserDataModule;

namespace HardTrainingViewsModel.UserDataModule
{
    public class UserDataViewModel : ViewModelBase
    {
        public UserDataViewModel()
        {
            
        }

        public UserBasicData UserData { get; private set; }
    }
}