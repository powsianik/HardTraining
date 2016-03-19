using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using HardTrainingViews.VMLocator;
using HardTrainingCore.Messages;
using HardTrainingViews.Views.Logger;

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
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
