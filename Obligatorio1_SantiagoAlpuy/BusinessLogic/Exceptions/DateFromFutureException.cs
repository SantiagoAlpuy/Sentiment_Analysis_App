using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class DateFromFutureException : Exception
    {
        public DateFromFutureException() { }

        public DateFromFutureException(string message)
            : base(message) { }
    }

}
