using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class LackOfObligatoryParametersException : Exception
    {
        public LackOfObligatoryParametersException() { }
    }

}
