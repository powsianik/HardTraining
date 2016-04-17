using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.UserDataModule;

namespace HardTrainingViews.Views.UserDataModule
{
    /// <summary>
    /// Interaction logic for UserDataView.xaml
    /// </summary>
    public partial class UserDataView : Page
    {
        public UserDataView()
        {
            InitializeComponent();

            Messenger.Default.Register<OpenViewMessage>(this, this.OpenView);
        }

        private void OpenView(OpenViewMessage msg)
        {
            if (msg.TypeOfViewToOpen == TypesOfViews.UserDataSetter)
            {
                var view = new UserDataSetterView();
                
                var vm = view.DataContext as UserDataViewModel;
                if (vm != null)
                {
                    vm.IdOfProfile = msg.ProfileId;
                }
                
                view.Show();
            }
        }
    }
}
