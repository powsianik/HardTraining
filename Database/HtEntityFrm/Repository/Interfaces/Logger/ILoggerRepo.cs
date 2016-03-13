using System.Linq;
using HardTrainingRepository.Models.Logger;

namespace HardTrainingRepository.Repository.Interfaces.Logger
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