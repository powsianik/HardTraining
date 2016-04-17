using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HardTrainingViews.VMLocator;
using HardTrainingCore.Messages;
using HardTrainingViews.Views.UserDataModule;
using HardTrainingViewsModel.UserDataModule;

namespace HardTrainingViews.Views.CommonModule
{
    /// <summary>
    /// Interaction logic for CommonWindow.xaml
    /// </summary>
    public partial class CommonWindow : Page
    {
        public CommonWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<ChangePageInCommonViewMessage>(this, this.OpenView);
        }

        private void OpenView(ChangePageInCommonViewMessage msg)
        {
            if (msg.TypeOfPageViewToOpen == TypesOfViews.UserData)
            {
                /*
                this.Content = new UserDataView();
                var vm = ((UserDataView) this.Content).DataContext as UserDataViewModel;
                if (vm != null)
                {
                    vm.IdOfProfile = msg.ProfileId;
                }
                */
            }
        }
    }
}
