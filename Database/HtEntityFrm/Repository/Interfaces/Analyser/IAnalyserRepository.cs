using System;
using System.Collections.Generic;
using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Repository.Interfaces.Analyser
{
    public interface IAnalyserRepository
    {
        IEnumerable<UserData> GetUserData(short profileId);
    }
}