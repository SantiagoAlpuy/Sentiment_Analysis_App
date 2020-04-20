using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class SentimentAlreadyExistsException : Exception
    {
        public SentimentAlreadyExistsException() { }

        public SentimentAlreadyExistsException(string message)
            : base(message) { }
    }

}
