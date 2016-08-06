using System.Windows.Controls;
using HardTrainingViewsModel.UserDataModule;

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
