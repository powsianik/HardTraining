using System.Linq;
using HardTrainingPoco.POCO.Logger;

namespace EntityFrameworkDomain.Repository.Interfaces.Logger
{
    public interface ILoggerRepo
    {
        IQueryable<Profile> GetProfiles();
        bool IsExistProfile(string login, string password);
        void AddProfile(Profile profile);
        void DeleteProfile(Profile id);
        void UpdateProfile(Profile profile);

        void SaveChanges();
        void Dispose();
    }
}