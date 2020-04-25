using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class SentimentDoesNotExistsException : Exception
    {
        public SentimentDoesNotExistsException() { }
    }

}
