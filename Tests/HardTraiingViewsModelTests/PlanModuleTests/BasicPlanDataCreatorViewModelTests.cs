using GalaSoft.MvvmLight.Messaging;
using HardTrainingCore.Messages;
using HardTrainingViewsModel.PlanModule;
using Moq;
using Xunit;

namespace HardTraiingViewsModelTests.PlanModuleTests
{
    public class BasicPlanDataCreatorViewModelTests
    {
        private BasicPlanDataCreatorViewModel sut;
        private Mock<IMessenger> mockMessenger;

        public BasicPlanDataCreatorViewModelTests()
        {
            this.sut = new BasicPlanDataCreatorViewModel();
            this.mockMessenger = new Mock<IMessenger>();
            this.sut.InjectMessenger(mockMessenger.Object);
        }    

        [Fact]
        public void SetBasicData_WhenCorrectDataInViewModel_SaveDataToPlanData()
        {
            sut.SaveAndGoNextCommand.Execute(null);

            Assert.NotNull(sut.PlanData);
        }

        [Fact]
        public void SaveAndGoNext_WhenNoError_SendMessageForNextPage()
        {
            sut.SaveAndGoNextCommand.Execute(null);
            mockMessenger.Verify(p => p.Send(It.IsAny<OpenViewInPlanCreatorMessage>()));
        }
    }
}