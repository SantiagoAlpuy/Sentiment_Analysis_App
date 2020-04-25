using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class SentimentAlreadyExistsException : Exception
    {
        public SentimentAlreadyExistsException() { }
    }

}
