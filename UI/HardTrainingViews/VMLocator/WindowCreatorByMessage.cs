using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Enums;
using HardTrainingCore.Messages;
using HardTrainingViews.Views.PlanModule.PlanCreator;

namespace HardTrainingViews.VMLocator
{
    public class WindowCreatorByMessage
    {
        public WindowCreatorByMessage()
        {
            Messenger.Default.Register<CreateWindowMessage>(this, this.CreateWindow);
        }

        private void CreateWindow(CreateWindowMessage msg)
        {
            switch (msg.TypeOfWindowToOpen)
            {
                case TypesOfWindow.PlanNavigator:
                {
                    PlanNavigatorWindow planWindow = new PlanNavigatorWindow();
                    planWindow.Show();
                    break;
                }
            }
        }
    }
}