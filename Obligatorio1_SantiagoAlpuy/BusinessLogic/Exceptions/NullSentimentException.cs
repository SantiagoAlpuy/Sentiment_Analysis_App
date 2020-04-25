using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NullSentimentException : Exception
    {
        public NullSentimentException() { }
    }

}
