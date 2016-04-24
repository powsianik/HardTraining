using System.Windows.Controls;
using HardTrainingViewsModel.UserDataModule;

namespace HardTrainingViews.Views.UserDataModule
{
    /// <summary>
    /// Interaction logic for UserDataSetterView.xaml
    /// </summary>
    public partial class UserDataSetterView : Page
    {
        public UserDataSetterView(short profileId)
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
