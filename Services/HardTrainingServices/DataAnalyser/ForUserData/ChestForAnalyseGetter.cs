﻿using System.Collections.Generic;
using System.Linq;
using EntityFrameworkDomain.Repository.Interfaces.Analyser;
using HardTrainingPoco.POCO.AnalyserModule;
using HardTrainingServiceInterfaces.DataAnalyser;

namespace HardTrainingServices.DataAnalyser.ForUserData
{
    public class ChestForAnalyseGetter : IDataForAnalyseGetter
    {
        private IAnalyserRepository repo;

        public ChestForAnalyseGetter(IAnalyserRepository repo)
        {
            this.repo = repo;
        }

        public List<DataForChart> GetData(short profileId)
        {
            var userData = this.repo.GetUserData(profileId);

            var results = new List<DataForChart>(userData.Count());
            foreach (var data in userData)
            {
                results.Add(new DataForChart(data.Chest, data.MeasureDate.ToOADate()));
            }

            return results;
        }
    }
}