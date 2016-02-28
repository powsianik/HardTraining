using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HardTrainingRepository.Models.Logger;

namespace HardTrainingRepository.Models.Context
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