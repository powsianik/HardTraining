using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.UserDataModule;
using Microsoft.Practices.ServiceLocation;

namespace HardTrainingViews.Views.UserDataModule
{
    /// <summary>
    /// Interaction logic for UserDataView.xaml
    /// </summary>
    public partial class UserDataView : Page
    {
        public UserDataView(short profileId)
        {
            InitializeComponent();

            var viewModel = this.DataContext as UserDataViewModel;
            if (viewModel != null)
            {
                viewModel.IdOfProfile = profileId;
            }
        }
    }
}
