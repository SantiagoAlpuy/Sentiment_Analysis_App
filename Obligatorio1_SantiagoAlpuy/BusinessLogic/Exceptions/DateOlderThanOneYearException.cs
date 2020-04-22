using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class DateOlderThanOneYearException : Exception
    {
        public DateOlderThanOneYearException() { }

        public DateOlderThanOneYearException(string message)
            : base(message) { }
    }

}
