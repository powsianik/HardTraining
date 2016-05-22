using System;
using System.Collections.Generic;
using HardTrainingPoco.POCO.AnalyserModule;

namespace HardTrainingServiceInterfaces.DataAnalyser
{
    public interface IDataForAnalyseGetter
    {
        List<DataForChart> GetData(short profileId);
    }
}