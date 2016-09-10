using HardTrainingCore.Enums.ViewsForPlanCreator;

namespace HardTrainingCore.Messages
{
    public class OpenViewInPlanCreatorMessage
    {
        public OpenViewInPlanCreatorMessage(TypesOfPages typeOfPage, short profileId = 0, object data = null)
        {
            this.TypesOfPage = typeOfPage;
            this.ProfileId = profileId;
        }

        public TypesOfPages TypesOfPage { get; private set; }
        public short ProfileId { get; private set; }
    }
}