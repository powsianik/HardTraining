using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Enums;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.Interfaces;

namespace HardTrainingViewsModel.CommonModule
{
    public class CommonModuleViewModel : ViewModelBase, IContainId
    {
        private IMessenger messenger;

        public CommonModuleViewModel()
        {
            this.InjectMessenger(MessengerInstance);
            this.ShowUserDataCommand = new RelayCommand(this.ShowUserData);
            this.ShowPlanCreatorCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(this.ShowPlanCreator);
        }

        public short IdOfProfile { private get; set; }

        public string Name => "CommonModule";

        public ICommand ShowUserDataCommand { get; private set; }

        public ICommand ShowPlanCreatorCommand { get; private set; }

        public void InjectMessenger(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        private void ShowUserData()
        {
            messenger.Send(new OpenViewMessage(TypesOfViews.UserData, IdOfProfile));
        }

        private void ShowPlanCreator()
        {
            messenger.Send(new CreateWindowMessage(TypesOfWindow.PlanNavigator, IdOfProfile));
        }
    }
}