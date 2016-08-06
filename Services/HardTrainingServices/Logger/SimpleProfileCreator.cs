using System;
using EntityFrameworkDomain.Repository;
using HardTrainingPoco.POCO.Logger;
using HardTrainingServiceInterfaces.Logger;

namespace HardTrainingServices.Logger
{
    public class SimpleProfileCreator :  IProfileCreator
    {
        private readonly ICreate<Profile> dbProfileCreator;

        public SimpleProfileCreator(ICreate<Profile> dbCreator)
        {
            this.dbProfileCreator = dbCreator;
        }

        public void CreateProfile(string name, string password)
        {
            Profile prf = new Profile() {CreationDate = DateTime.Now, Name = name, Password = password};

            dbProfileCreator.Create(prf);
        }

    }
}
