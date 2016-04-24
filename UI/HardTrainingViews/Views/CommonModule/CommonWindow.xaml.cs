using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HardTrainingViews.VMLocator;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.CommonModule;


namespace HardTrainingViews.Views.CommonModule
{
    /// <summary>
    /// Interaction logic for CommonWindow.xaml
    /// </summary>
    public partial class CommonWindow : Page
    {
        public CommonWindow(short profileId)
        {
            InitializeComponent();

            this.ShowsNavigationUI = false;
            var viewModel = this.DataContext as CommonModuleViewModel;
            if (viewModel != null)
            {
                viewModel.IdOfProfile = profileId;
            }
        }
    }
}
