using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingCore.Messages;

namespace HardTrainingViewsModel.CommonModule
{
    public class CommonModuleViewModel : ViewModelBase
    {
        public CommonModuleViewModel()
        {
            this.ShowUserDataCommand = new RelayCommand(this.ShowUserData);
        }

        public string Name => "CommonModule";

        public ICommand ShowUserDataCommand { get; private set; }

        private void ShowUserData()
        {
            MessengerInstance.Send(new ChangePageInCommonViewMessage(TypesOfViews.UserData));
        }
    }
}