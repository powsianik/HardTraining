using System;
using System.Linq;
using EntityFrameworkDomain.Context.Interfaces;
using EntityFrameworkDomain.Repository.Interfaces.UserDataModule;
using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Repository.Concrete.UserDataModule
{
    public class UserDataRepository : IUserDataRepo
    {
        private IHardTrainingContext db;

        public UserDataRepository(IHardTrainingContext context)
        {
            this.db = context;
        }

        public UserData GetUserData(short profileId)
        {
            var userData = this.db.UserDatas.FirstOrDefault(ud => ud.ProfileId == profileId);

            return userData;
        }
    }
}