using System;

namespace Exceptions
{
    [Serializable]
    public class NullSentimentException : Exception
    {
        public NullSentimentException() { }

        public NullSentimentException(string message)
            : base(message) { }
    }

}
