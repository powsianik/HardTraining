using EntityFrameworkDomain.Repository;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingPoco.POCO.Logger;

namespace HardTrainingServices.Logger
{
    public class SimpleProfileDeleter
    {
        private readonly IDelete<Profile> dbProfileDeleter;
        private readonly ProfileFinder profileFinder;

        public SimpleProfileDeleter(IDelete<Profile> deleter, ILoggerRepo repo)
        {
            this.dbProfileDeleter = deleter;
            this.profileFinder = new ProfileFinder(repo);
        }

        public void Delete(string name, string pass)
        {
            var profileToDelete = this.profileFinder.FindProfile(name, pass);

            this.dbProfileDeleter.Delete(profileToDelete);
        }
    }
}