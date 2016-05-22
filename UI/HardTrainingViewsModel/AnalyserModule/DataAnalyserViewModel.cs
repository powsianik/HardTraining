using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkDomain.Repository.Interfaces.Analyser;
using GalaSoft.MvvmLight;
using HardTrainingPoco.POCO.UserDataModule;
using HardTrainingViewsModel.Interfaces;


namespace HardTrainingViewsModel.AnalyserModule
{
    public class DataAnalyserViewModel : ViewModelBase, IContainId
    {
        private IAnalyserRepository repo;
        private IEnumerable<UserData> userData; 

        public DataAnalyserViewModel(IAnalyserRepository repo)
        {
            this.repo = repo;   
        }

        public short IdOfProfile {private get; set; }

        public List<DataForChart> DataForChart { get; private set; }

        public void PrepareWeightDataForChart()
        {
            this.userData = repo.GetUserData(this.IdOfProfile);

            this.DataForChart = new List<DataForChart>(10);

            foreach (var data in this.userData)
            {
                this.DataForChart.Add(new DataForChart(data.Weight, data.MeasureDate.ToOADate()));
            }
        }
    }
}