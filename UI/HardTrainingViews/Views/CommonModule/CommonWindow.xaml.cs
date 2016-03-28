﻿using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingViews.VMLocator;
using HardTrainingCore.Messages;
using HardTrainingViews.Views.UserDataModule;

namespace HardTrainingViews.Views.CommonModule
{
    /// <summary>
    /// Interaction logic for CommonWindow.xaml
    /// </summary>
    public partial class CommonWindow : Window
    {
        public CommonWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<ChangePageInCommonViewMessage>(this, this.OpenView);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void OpenView(ChangePageInCommonViewMessage msg)
        {
            if (msg.TypeOfPageViewToOpen == TypesOfViews.UserData)
            {
                this.Content = new UserDataView();
            }
        }
    }
}
