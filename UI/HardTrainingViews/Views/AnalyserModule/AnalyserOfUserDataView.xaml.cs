using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HardTrainingPoco.POCO.AnalyserModule;
using HardTrainingViewsModel.AnalyserModule;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;


namespace HardTrainingViews.Views.AnalyserModule
{
    /// <summary>
    /// Interaction logic for AnalyserOfUserDataView.xaml
    /// </summary>
    public partial class AnalyserOfUserDataView : Page
    {
        public EnumerableDataSource<DataForChart> sad { get; set; }

        public AnalyserOfUserDataView(short profileId)
        {
            InitializeComponent();

            var viewModel = this.DataContext as DataAnalyserViewModel;
            if (viewModel != null)
            {
                viewModel.IdOfProfile = profileId;
            }
        }

        public void CreateChart(object seder, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as DataAnalyserViewModel;
            if (viewModel != null)
            {
                viewModel.PrepareDataForChart(((ComboBoxItem)this.cbxDataToAnalyse.SelectedValue).Content.ToString());

                var ds = new EnumerableDataSource<DataForChart>(viewModel.DataForChart);

                ds.SetXMapping(x => x.DateOfMeasurment);
                ds.SetYMapping(y => y.ValueOfMeasure);

                var line = new LineGraph(ds);
                line.LinePen = new Pen(Brushes.Blue, 2);

                plotter.Children.RemoveAllOfType(typeof(LineGraph));
                plotter.Children.Add(line);
                plotter.FitToView();
            } 
        }
    }
}
