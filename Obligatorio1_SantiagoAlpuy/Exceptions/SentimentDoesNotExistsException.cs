using System;

namespace Exceptions
{
    [Serializable]
    public class SentimentDoesNotExistsException : Exception
    {
        public SentimentDoesNotExistsException() { }

        public SentimentDoesNotExistsException(string message)
            : base(message) { }
    }

}
