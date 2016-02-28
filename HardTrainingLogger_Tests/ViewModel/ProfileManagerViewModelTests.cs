using HardTrainingLogger.ViewModel;
using HardTrainingLogger.Views.UserControls;
using HardTrainingRepository.Models.Logger;
using HardTrainingRepository.Repositories;
using Moq;
using NUnit.Framework;

namespace HardTrainingLogger_Tests.ViewModel
{
    [TestFixture, RequiresSTA]
    public class ProfileManagerViewModelTests
    {
        private ProfileManagerViewModel sut;    //System Under Tests
        private Mock<ILoggerRepo> mockLoggerRepo;
            
        [SetUp]
        public void SetUp()
        {
            this.mockLoggerRepo = new Mock<ILoggerRepo>();

            this.sut = new ProfileManagerViewModel(mockLoggerRepo.Object);
        }

        [Test]
        public void DeleteProfile_WhenCorrectData_CallDeleteProfileFromRepository()
        {
            //Arrange
            this.mockLoggerRepo.Setup(r => r.DeleteProfile(It.IsAny<Profile>())).Verifiable();
            this.sut.SelectedProfile = new Profile() {Name = "name", Password = "pass"};
            this.sut.ProfileName = "name";
            this.sut.ProfilePassword = "pass";


            //Act
            this.sut.DeleteProfileCommand.Execute(null);

            //Assert
            this.mockLoggerRepo.Verify(r=>r.DeleteProfile(It.IsAny<Profile>()), Times.Once);
        }

        [Test]
        public void DeleteProfile_WhenWrongData_NotCallDeleteProfileFromRepository()
        {
            //Arrange
            this.mockLoggerRepo.Setup(r => r.DeleteProfile(It.IsAny<Profile>())).Verifiable();
            this.sut.SelectedProfile = new Profile() { Name = "nameProfile", Password = "password" };
            this.sut.ProfileName = "name";
            this.sut.ProfilePassword = "pass";


            //Act
            this.sut.DeleteProfileCommand.Execute(null);

            //Assert
            this.mockLoggerRepo.Verify(r => r.DeleteProfile(It.IsAny<Profile>()), Times.Never);
        }

        [Test]
        public void CreateProfile_WhenCorrectData_CallAddProfileFromRepository()
        {
            //Arrange:
            this.mockLoggerRepo.Setup(r=>r.AddProfile(It.IsAny<Profile>())).Verifiable();

            //Act:
            this.sut.CreateProfileCommand.Execute(null);

            //Assert:
            this.mockLoggerRepo.Verify(r=>r.AddProfile(It.IsAny<Profile>()), Times.Once());
        }
    }
}