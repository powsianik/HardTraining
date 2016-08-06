using HardTrainingCore.Enums;

namespace HardTrainingCore.Messages
{
    public class CreateWindowMessage
    {
        public CreateWindowMessage(TypesOfWindow typeOfWindowToOpen, short profileId = 0)
        {
            this.TypeOfWindowToOpen = typeOfWindowToOpen;
            this.ProfileId = profileId;
        }

        public TypesOfWindow TypeOfWindowToOpen { get; private set; }
        public short ProfileId { get; private set; }
    }
}