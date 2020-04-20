using System;

namespace Exceptions
{
    [Serializable]
    public class LackOfObligatoryParametersException : Exception
    {
        public LackOfObligatoryParametersException() { }

        public LackOfObligatoryParametersException(string message)
            : base(message) { }
    }

}
