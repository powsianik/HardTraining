using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Enums.ViewsForPlanCreator;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.Interfaces;
using HardTrainingViewsModel.PlanModule.DataForViewModel;
using GalaSoft.MvvmLight.Command;

namespace HardTrainingViewsModel.PlanModule
{
    public class BasicPlanDataCreatorViewModel : ViewModelBase, IContainId
    {
        private IMessenger messenger;

        public BasicPlanDataCreatorViewModel()
        {
            this.PlanData = new TrainingPlanData();
            this.InjectMessenger(MessengerInstance);
            this.SaveAndGoNextCommand = new RelayCommand(this.SaveAndGoNext);       
        }

        public short IdOfProfile { private get; set; }
        public TrainingPlanData PlanData { get; set; }

        public ICommand SaveAndGoNextCommand { get; private set; }

        public void InjectMessenger(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        private void SaveAndGoNext()
        {
            messenger.Send(new OpenViewInPlanCreatorMessage(TypesOfPages.DaySelection, IdOfProfile));
        }
    }
}