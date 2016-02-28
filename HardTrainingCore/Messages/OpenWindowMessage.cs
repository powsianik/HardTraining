using System;

namespace HardTrainingCore.Messages
{
    public class OpenWindowMessage
    {
        public OpenWindowMessage(Type windowType)
        {
            this.TypeOfWindowToOpen = windowType;
        }

        public Type TypeOfWindowToOpen { get; private set; }
    }
}
