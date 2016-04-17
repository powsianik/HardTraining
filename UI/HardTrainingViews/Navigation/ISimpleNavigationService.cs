using System;
using System.Windows.Navigation;

namespace HardTrainingViews.Navigation
{
    public interface ISimpleNavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri pageUri);
    }
}