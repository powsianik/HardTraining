using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingCore.Enums;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.Interfaces;

namespace HardTrainingViewsModel.CommonModule
{
    public class CommonModuleViewModel : ViewModelBase, IContainId
    {
        public CommonModuleViewModel()
        {
            this.ShowUserDataCommand = new RelayCommand(this.ShowUserData);
        }

        public short IdOfProfile { private get; set; }

        public string Name => "CommonModule";

        public ICommand ShowUserDataCommand { get; private set; }

        private void ShowUserData()
        {
            MessengerInstance.Send(new OpenViewMessage(TypesOfViews.UserData, IdOfProfile));
        }
    }
}