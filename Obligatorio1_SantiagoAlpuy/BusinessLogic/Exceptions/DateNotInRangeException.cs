using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class DateNotInRangeException : Exception
    {
        public DateNotInRangeException()
        {
        }

        public DateNotInRangeException(String message) : base(message)
        {

        }
    }
}
