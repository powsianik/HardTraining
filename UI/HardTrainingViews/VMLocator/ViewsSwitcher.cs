using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Enums;
using HardTrainingCore.Enums.ViewsForPlanCreator;
using HardTrainingCore.Messages;
using HardTrainingViews.Navigation;
using HardTrainingViews.Views.AnalyserModule;
using HardTrainingViews.Views.CommonModule;
using HardTrainingViews.Views.UserDataModule;
using Microsoft.Practices.ServiceLocation;
using System.Windows;
using HardTrainingViews.Views.PlanModule.PlanCreator.Pages;

namespace HardTrainingViews.VMLocator
{
    public class ViewsSwitcher
    {
        public ViewsSwitcher()
        {
            Messenger.Default.Register<OpenViewMessage>(this, this.ViewTransition);
            Messenger.Default.Register<BackToRecentViewMessage>(this, this.BackToView);
            Messenger.Default.Register<OpenViewInPlanCreatorMessage>(this, this.PlanCreatorViewTransition);
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

        private void PlanCreatorViewTransition(OpenViewInPlanCreatorMessage msg)
        {
            switch (msg.TypesOfPage)
            {
                case TypesOfPages.BasicData:
                    ServiceLocator.Current.GetInstance<ISimpleNavigationService>().NavigateTo(new BasicPlanDataCreator());
                    break;
            }
        }

        private void BackToView(BackToRecentViewMessage msg)
        {
            ServiceLocator.Current.GetInstance<ISimpleNavigationService>().Back();
        }
    }
}