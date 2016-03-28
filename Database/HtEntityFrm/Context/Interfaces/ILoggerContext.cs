using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HardTrainingPoco.POCO.Logger;

namespace EntityFrameworkDomain.Context.Interfaces
{
    public interface ILoggerContext
    {
        Database Database { get; }
        DbSet<Profile> Profiles { get; set; }

        DbEntityEntry Entry(object entity);

        int SaveChanges();

        void Dispose();
    }
}