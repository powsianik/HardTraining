using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using EntityFrameworkDomain.Models.Logger;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingServices.Logger;
using Moq;
using NUnit.Framework;

namespace HardTrainingServicesTests.Logger
{
    [TestFixture]
    public class ProfileCheckerTests
    {
        private Mock<ILoggerRepo> mockLoggerRepo;
        private ProfileChecker systemUnderTests;
        private IQueryable<Profile> existingProfiles;
        private const string name = "aaaaaa";
        private const string pass = "bbbbbb";

        [SetUp]
        public void SetUp()
        {
            this.mockLoggerRepo = new Mock<ILoggerRepo>();
            this.systemUnderTests = new ProfileChecker(mockLoggerRepo.Object);

            existingProfiles =
                new EnumerableQuery<Profile>(new List<Profile>()
                {
                    new Profile() {Id = 1, Name = "aaaaaa", Password = "bbbbbb"}
                });
        }

        [Test]
        public void IsExistProfile_WhenProfileWithNameAndPasswordPutInParamsExist_ReturnsTrue()
        {
            mockLoggerRepo.Setup(lr => lr.GetProfiles()).Returns(existingProfiles);

            var result = this.systemUnderTests.IsExistProfile(name, pass);
            const bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsExistProfile_WhenProfileWithNameAndpasswordPutInParamsNotExist_ReturnsFalse()
        {
            mockLoggerRepo.Setup(lr => lr.GetProfiles()).Returns(existingProfiles);

            var result = this.systemUnderTests.IsExistProfile(pass, name);
            const bool expected = false;

            Assert.AreEqual(expected, expected);
        }
    }
}