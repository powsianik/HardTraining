using System.Linq;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingPoco.POCO.Logger;

namespace HardTrainingServices.Logger
{
    internal class ProfileFinder
    {
        private readonly ILoggerRepo loggerRepo;

        public ProfileFinder(ILoggerRepo repo)
        {
            this.loggerRepo = repo;
        }

        public Profile FindProfile(string name, string pass)
        {
            var prf = this.loggerRepo.GetProfiles().FirstOrDefault(p => p.Name.Equals(name) && p.Password.Equals(pass));

            return prf;
        }
    }
}