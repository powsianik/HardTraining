using System.Linq;
using EntityFrameworkDomain.Context.Interfaces;
using EntityFrameworkDomain.Repository.Interfaces.UserDataModule;
using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Repository.Concrete.UserDataModule
{
    public class UserDataRepository : IUserDataRepo
    {
        private readonly IHardTrainingContext db;

        public UserDataRepository(IHardTrainingContext context)
        {
            this.db = context;
        }

        public UserData GetUserData(short profileId)
        {
            var userData =
                this.db.UserDatas.Where(ud => ud.ProfileId == profileId).OrderByDescending(ud => ud.MeasureDate).FirstOrDefault();
            return userData;
        }

        public void SaveUserData(UserData userData)
        {
            if (userData != null)
            {
                this.db.UserDatas.Add(userData);
            }
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
    }
}