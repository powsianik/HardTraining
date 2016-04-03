
namespace HardTrainingCore.Messages
{
    public class OpenViewMessage
    {
        public OpenViewMessage(TypesOfViews typeOfView, short profileId = 0)
        {
            this.TypeOfViewToOpen = typeOfView;
            this.ProfileId = profileId;
        }

        public TypesOfViews TypeOfViewToOpen { get; private set; }
        public short ProfileId { get; private set; }
    }
}
