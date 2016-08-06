using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HardTrainingViews.Navigation
{
    public interface ISimpleNavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Page page);

        void SetNavigationWindow(NavigationWindow window);

        void Back();
    }
}