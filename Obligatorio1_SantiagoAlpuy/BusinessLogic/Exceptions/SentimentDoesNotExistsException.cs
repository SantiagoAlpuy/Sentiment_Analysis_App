using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class SentimentDoesNotExistsException : Exception
    {
        public SentimentDoesNotExistsException() { }

        public SentimentDoesNotExistsException(string message)
            : base(message) { }
    }

}
