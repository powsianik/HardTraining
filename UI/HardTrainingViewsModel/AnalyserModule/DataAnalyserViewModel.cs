using System;
using GalaSoft.MvvmLight;
using HardTrainingViewsModel.Interfaces;
using OxyPlot;
using OxyPlot.Series;


namespace HardTrainingViewsModel.AnalyserModule
{
    public class DataAnalyserViewModel : ViewModelBase, IContainId
    {
        public DataAnalyserViewModel()
        {
            this.PrepareGraph();
        }

        public short IdOfProfile { get; set; }

        public PlotModel ModelOfGraph { get; private set; }

        private void PrepareGraph()
        {
            this.ModelOfGraph = new PlotModel() {Title = "asdsa"};
            this.ModelOfGraph.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));;
        }
    }
}