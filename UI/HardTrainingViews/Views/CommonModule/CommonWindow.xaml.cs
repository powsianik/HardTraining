using System.Windows;
using HardTraining.VMLocator;

namespace HardTraining.Views.CommonModule
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
