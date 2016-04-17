namespace HardTrainingCore.Messages
{
    public class ChangePageInCommonViewMessage
    {
        public ChangePageInCommonViewMessage(TypesOfViews typeOfView, short profileId)
        {
            this.TypeOfPageViewToOpen = typeOfView;
            this.ProfileId = profileId;
        }

        public TypesOfViews TypeOfPageViewToOpen { get; private set; }
        public short ProfileId { get; private set; }
    }
}