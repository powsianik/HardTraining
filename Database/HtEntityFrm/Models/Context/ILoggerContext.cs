using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFrameworkDomain.Models.Logger;

namespace EntityFrameworkDomain.Models.Context
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