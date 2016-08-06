using System.Linq;
using EntityFrameworkDomain.Repository;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingPoco.POCO.Logger;

namespace HardTrainingServices.Logger
{
    public class ProfileChecker
    {
        private readonly IReadAll<Profile> profileReader;

        public ProfileChecker(IReadAll<Profile> profileReader)
        {
            this.profileReader = profileReader;
        }

        public bool IsExistProfile(string name, string password, out short profileId)
        {
            var profile =
                this.profileReader.ReadAll().FirstOrDefault(p => p.Name.Equals(name) && p.Password.Equals(password));

            if (profile != null)
            {
                profileId = profile.Id;
                return true;
            }
            else
            {
                profileId = 0;
                return false;
            }
        }
    }
}