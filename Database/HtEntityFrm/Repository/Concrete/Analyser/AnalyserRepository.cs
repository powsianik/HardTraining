using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkDomain.Context.Interfaces;
using EntityFrameworkDomain.Repository.Interfaces.Analyser;
using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Repository.Concrete.Analyser
{
    public class AnalyserRepository : IAnalyserRepository
    {
        private readonly IHardTrainingContext db;

        public AnalyserRepository(IHardTrainingContext context)
        {
            this.db = context;
        }

        public IEnumerable<UserData> GetUserData(short profileId)
        {
            var results = this.db.UserDatas.Where(d => d.ProfileId == profileId).OrderBy(d => d.MeasureDate).AsEnumerable();
            return results;
        }
    }
}