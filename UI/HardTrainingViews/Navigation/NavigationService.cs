using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HardTrainingViews.Navigation
{
    public class NavigationService : ISimpleNavigationService
    {
        private NavigationWindow navigationWindow;

        public event NavigatingCancelEventHandler Navigating;

        public void Back()
        {
            if (CheckIfExistNavigationWindow())
            {
                navigationWindow.GoBack();
            }
        }

        public void NavigateTo(Page page)
        {
            if (CheckIfExistNavigationWindow())
            {
                navigationWindow.Navigate(page);
            }
        }

        public void NavigateTo(Uri pageUri)
        {
            if (CheckIfExistNavigationWindow())
            {
                navigationWindow.Navigate(pageUri);
            }
        }

        public void SetNavigationWindow(NavigationWindow window)
        {
            this.navigationWindow = window;
        }

        private bool CheckIfExistNavigationWindow()
        {
            if (navigationWindow != null)
            {
                return true;
            }

            navigationWindow = (NavigationWindow) Application.Current.MainWindow;
            

            if (navigationWindow != null)
            {
                // Could be null if the app runs inside a design tool
                navigationWindow.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;
        }
    }
}