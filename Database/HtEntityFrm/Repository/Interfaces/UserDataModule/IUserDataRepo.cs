using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Repository.Interfaces.UserDataModule
{
    public interface IUserDataRepo
    {
        UserData GetUserData(short profileId);
    }
}