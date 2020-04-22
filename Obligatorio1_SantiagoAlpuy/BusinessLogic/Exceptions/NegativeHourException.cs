using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NegativeDayException : Exception
    {
        public NegativeDayException() { }

        public NegativeDayException(string message)
            : base(message) { }
    }

}
