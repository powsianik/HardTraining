using System.Linq;
using EntityFrameworkDomain.Models.Logger;

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