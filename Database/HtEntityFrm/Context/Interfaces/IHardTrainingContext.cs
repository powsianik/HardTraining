using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HardTrainingPoco.POCO.Logger;
using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Context.Interfaces
{
    public interface IHardTrainingContext
    {
        Database Database { get; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<UserData> UserDatas { get; set; }

        DbEntityEntry Entry(object entity);

        int SaveChanges();

        void Dispose();
    }
}