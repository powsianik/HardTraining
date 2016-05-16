using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;
using HardTrainingViews.Navigation;
using HardTrainingViews.Views.AnalyserModule;
using HardTrainingViews.Views.CommonModule;
using HardTrainingViews.Views.UserDataModule;
using Microsoft.Practices.ServiceLocation;

namespace HardTrainingViews.VMLocator
{
    public class ViewsSwitcher
    {
        public ViewsSwitcher()
        {
            Messenger.Default.Register<OpenViewMessage>(this, this.ViewTransition);
            Messenger.Default.Register<BackToRecentViewMessage>(this, this.BackToView);
        }

        private void ViewTransition(OpenViewMessage msg)
        {
            switch (msg.TypeOfViewToOpen)
            {
                case TypesOfViews.CommonViewModule:
                    ServiceLocator.Current.GetInstance<ISimpleNavigationService>().NavigateTo(new CommonWindow(msg.ProfileId));
                    break;
                case TypesOfViews.UserData:
                    ServiceLocator.Current.GetInstance<ISimpleNavigationService>().NavigateTo(new UserDataView(msg.ProfileId));
                    break;
                case TypesOfViews.UserDataSetter:
                    ServiceLocator.Current.GetInstance<ISimpleNavigationService>().NavigateTo(new UserDataSetterView(msg.ProfileId));
                    break;
                case TypesOfViews.AnalyserOfUserDataInTime:
                    ServiceLocator.Current.GetInstance<ISimpleNavigationService>().NavigateTo(new AnalyserOfUserDataView(msg.ProfileId));
                    break;
            }
        }

        private void BackToView(BackToRecentViewMessage msg)
        {
            ServiceLocator.Current.GetInstance<ISimpleNavigationService>().Back();
        }
    }
}