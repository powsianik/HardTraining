using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
