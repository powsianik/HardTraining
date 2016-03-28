namespace HardTrainingCore.Messages
{
    public class ChangePageInCommonViewMessage
    {
        public ChangePageInCommonViewMessage(TypesOfViews typeOfView)
        {
            this.TypeOfPageViewToOpen = typeOfView;
        }

        public TypesOfViews TypeOfPageViewToOpen { get; private set; }
    }
}