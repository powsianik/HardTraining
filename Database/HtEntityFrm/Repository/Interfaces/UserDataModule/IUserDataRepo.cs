using HardTrainingPoco.POCO.UserDataModule;

namespace EntityFrameworkDomain.Repository.Interfaces.UserDataModule
{
    public interface IUserDataRepo
    {
        UserData GetUserData(short profileId);
        void SaveUserData(UserData userData);
        void SaveChanges();
    }
}