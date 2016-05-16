using System.Windows.Controls;
using HardTrainingViewsModel.AnalyserModule;
using HardTrainingViewsModel.UserDataModule;

namespace HardTrainingViews.Views.AnalyserModule
{
    /// <summary>
    /// Interaction logic for AnalyserOfUserDataView.xaml
    /// </summary>
    public partial class AnalyserOfUserDataView : Page
    {
        public AnalyserOfUserDataView(short profileId)
        {
            InitializeComponent();

            var viewModel = this.DataContext as DataAnalyserViewModel;
            if (viewModel != null)
            {
                viewModel.IdOfProfile = profileId;
            }
        }
    }
}
