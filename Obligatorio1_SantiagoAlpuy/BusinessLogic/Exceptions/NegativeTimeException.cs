using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NegativeTimeException : Exception
    {
        public NegativeTimeException() { }

        public NegativeTimeException(string message)
            : base(message) { }
    }

}
