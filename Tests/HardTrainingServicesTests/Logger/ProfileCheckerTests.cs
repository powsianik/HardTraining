using System.Collections.Generic;
using System.Linq;
using EntityFrameworkDomain.Repository;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingPoco.POCO.Logger;
using HardTrainingServices.Logger;
using Moq;
using NUnit.Framework;

namespace HardTrainingServicesTests.Logger
{
    [TestFixture]
    public class ProfileCheckerTests
    {
        private Mock<IReadAll<Profile>> mockEntityReader;
        private ProfileChecker systemUnderTests;
        private IQueryable<Profile> existingProfiles;
        private const string name = "aaaaaa";
        private const string pass = "bbbbbb";

        [SetUp]
        public void SetUp()
        {
            this.mockEntityReader = new Mock<IReadAll<Profile>>();
            this.systemUnderTests = new ProfileChecker(mockEntityReader.Object);

            existingProfiles =
                new EnumerableQuery<Profile>(new List<Profile>()
                {
                    new Profile() {Id = 1, Name = "aaaaaa", Password = "bbbbbb"}
                });
        }

        [Test]
        public void IsExistProfile_WhenProfileWithNameAndPasswordPutInParamsExist_ReturnsTrue()
        {
            mockEntityReader.Setup(lr => lr.ReadAll()).Returns(existingProfiles);

            short profileId;
            var result = this.systemUnderTests.IsExistProfile(name, pass, out profileId);
            const bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsExistProfile_WhenProfileWithNameAndpasswordPutInParamsNotExist_ReturnsFalse()
        {
            mockEntityReader.Setup(lr => lr.ReadAll()).Returns(existingProfiles);

            short profileId;
            var result = this.systemUnderTests.IsExistProfile(pass, name, out profileId);
            const bool expected = false;

            Assert.AreEqual(expected, expected);
        }
    }
}