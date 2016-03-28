
namespace HardTrainingCore.Messages
{
    public class OpenViewMessage
    {
        public OpenViewMessage(TypesOfViews typeOfView)
        {
            this.TypeOfViewToOpen = typeOfView;
        }

        public TypesOfViews TypeOfViewToOpen { get; private set; }
    }
}
