using System;
using System.Collections.Generic;
using HardTrainingViewsModel.AnalyserModule;

namespace HardTrainingServiceInterfaces.DataAnalyser
{
    public interface IDataForAnalyseGetter
    {
        List<DataForChart> GetData(short profileId);
    }
}