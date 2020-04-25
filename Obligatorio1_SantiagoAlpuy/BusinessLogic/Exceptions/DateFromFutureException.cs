using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class DateFromFutureException : Exception
    {
        public DateFromFutureException() { }
    }

}
