using System.Collections.Generic;
using System.Windows.Input;
using EntityFrameworkDomain.Repository.Interfaces.Analyser;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HardTrainingPoco.POCO.UserDataModule;
using HardTrainingServices.DataAnalyser;
using HardTrainingViewsModel.Interfaces;


namespace HardTrainingViewsModel.AnalyserModule
{
    public class DataAnalyserViewModel : ViewModelBase, IContainId
    {
        private IAnalyserRepository repo;

        public DataAnalyserViewModel(IAnalyserRepository repo)
        {
            this.repo = repo;

            this.PrepareDataForChartCommand = new RelayCommand<string>(this.PrepareDataForChart);

            this.DataForChart = new List<DataForChart>();
        }

        public ICommand PrepareDataForChartCommand { get; private set; }

        public short IdOfProfile {private get; set; }

        public List<DataForChart> DataForChart { get; private set; }

        public void PrepareDataForChart(string dataToAnalyseName)
       {
            switch (dataToAnalyseName)
            {
                case "Waga":
                    {
                        var dataGetter = new WeightForAnalyseGetter(this.repo);
                        this.DataForChart = dataGetter.GetData(this.IdOfProfile);
                        break;
                    }
                default:
                    {
                        var dataGetter = new WeightForAnalyseGetter(this.repo);
                        this.DataForChart = dataGetter.GetData(this.IdOfProfile);
                        break;
                    }
            }
        }
    }
}