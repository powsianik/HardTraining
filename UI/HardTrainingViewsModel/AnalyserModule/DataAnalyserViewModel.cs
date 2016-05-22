using System.Collections.Generic;
using System.Windows.Input;
using EntityFrameworkDomain.Repository.Interfaces.Analyser;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HardTrainingCore.Messages;
using HardTrainingPoco.POCO.AnalyserModule;
using HardTrainingPoco.POCO.UserDataModule;
using HardTrainingServices.DataAnalyser;
using HardTrainingServices.DataAnalyser.ForUserData;
using HardTrainingViewsModel.Interfaces;


namespace HardTrainingViewsModel.AnalyserModule
{
    public class DataAnalyserViewModel : ViewModelBase, IContainId
    {
        private IAnalyserRepository repo;

        public DataAnalyserViewModel(IAnalyserRepository repo)
        {
            this.repo = repo;

            this.PrepareDataForChartCommand = new GalaSoft.MvvmLight.Command.RelayCommand<string>(this.PrepareDataForChart);
            this.BackToRecentViewCommand = new RelayCommand(this.BackToRecentView);

            this.DataForChart = new List<DataForChart>();
        }

        public ICommand PrepareDataForChartCommand { get; private set; }

        public ICommand BackToRecentViewCommand { get; private set; }

        public short IdOfProfile {private get; set; }

        public List<DataForChart> DataForChart { get; private set; }

        public void PrepareDataForChart(string dataToAnalyseName)
       {
            switch (dataToAnalyseName)
            {
                case "Waga":
                case "Weight":
                    {
                        var dataGetter = new WeightForAnalyseGetter(this.repo);
                        this.DataForChart = dataGetter.GetData(this.IdOfProfile);
                        break;
                    }
                case "Ramię":
                case "Arm":
                    {
                        var dataGetter = new ArmForAnalyseGetter(this.repo);
                        this.DataForChart = dataGetter.GetData(this.IdOfProfile);
                        break;
                    }
                case "Klatka Piersiowa":
                case "Chest":
                    {
                        var dataGetter = new ChestForAnalyseGetter(this.repo);
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

        private void BackToRecentView()
        {
            MessengerInstance.Send(new BackToRecentViewMessage());
        }
    }
}