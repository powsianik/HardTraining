namespace HardTrainingCore.Messages
{
    public class ChangePageInCommonViewMessage
    {
        public ChangePageInCommonViewMessage(TypesOfViews typeOfView, int profileId)
        {
            this.TypeOfPageViewToOpen = typeOfView;
            this.ProfileId = profileId;
        }

        public TypesOfViews TypeOfPageViewToOpen { get; private set; }
        public int ProfileId { get; private set; }
    }
}