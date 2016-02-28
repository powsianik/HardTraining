using HardTrainingLogger.ViewModel;
using HardTrainingRepository.Repositories;
using Moq;
using NUnit.Framework;

namespace HardTrainingLogger_Tests.ViewModel
{
    [TestFixture]
    public class LoggerViewModelTests
    {
        private LoggerViewModel _loggerViewModel;
        private Mock<ILoggerRepo> _mockLoggerRepo;

        [SetUp]
        public void SetUp()
        {
            this._mockLoggerRepo = new Mock<ILoggerRepo>();
            this._loggerViewModel = new LoggerViewModel(_mockLoggerRepo.Object);
        }

        [Test]
        public void LogOn_PassAndOrLoginIncorrect_ReturnFalse()
        {
            //Arrange:
            _mockLoggerRepo.Setup(r => r.IsExistProfile(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            const bool expectedvalue = false;

            //Act: 
            bool resultValue = _loggerViewModel.LogOn(string.Empty, string.Empty);

            //Assert:
            Assert.AreEqual(expectedvalue, resultValue);
        }

        [Test]
        public void LogOn_PassAndLoginCorrect_ReturnTrue()
        {
            //Arrange:
            _mockLoggerRepo.Setup(x => x.IsExistProfile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            const bool expectedvalue = true;

            //Act: 
            bool resultValue = _loggerViewModel.LogOn(string.Empty, string.Empty);

            //Assert:
            Assert.AreEqual(expectedvalue, resultValue);
        }
    }
}
