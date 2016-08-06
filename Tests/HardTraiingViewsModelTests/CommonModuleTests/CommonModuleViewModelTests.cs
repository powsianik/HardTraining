using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;
using Xunit;
using HardTrainingViewsModel.CommonModule;
using Moq;

namespace HardTraiingViewsModelTests.CommonModuleTests
{
    public class CommonModuleViewModelTests
    {
        private CommonModuleViewModel sut;
        private Mock<IMessenger> mockMessenger;

        public CommonModuleViewModelTests()
        {
            this.sut = new CommonModuleViewModel();
            this.mockMessenger = new Mock<IMessenger>();
            this.sut.InjectMessenger(mockMessenger.Object);
        }

        [Fact]
        public void ShowUserDataCommand_WhenExecuted_SendOpenViewMessage()
        {
            sut.ShowUserDataCommand.Execute(null);
            mockMessenger.Verify(p => p.Send(It.IsAny<OpenViewMessage>()));
        }

        [Fact]
        public void ShowPlanCreatorCommand_WhenExecuted_SendMesage()
        {
            sut.ShowPlanCreatorCommand.Execute(null);
            mockMessenger.Verify(p => p.Send(It.IsAny<CreateWindowMessage>()));
        }
    }
}