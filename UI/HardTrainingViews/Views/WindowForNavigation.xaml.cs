using System;
using System.Windows;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;

namespace HardTrainingViews.Views
{
    /// <summary>
    /// Interaction logic for WindowForNavigation.xaml
    /// </summary>
    public partial class WindowForNavigation : NavigationWindow
    {
        public WindowForNavigation(short profileId)
        {
            InitializeComponent();

            Application.Current.MainWindow = this;

            Messenger.Default.Send(new OpenViewMessage(TypesOfViews.CommonViewModule, profileId));
        }

    }
}
