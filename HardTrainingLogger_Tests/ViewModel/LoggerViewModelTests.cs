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
    }
}
