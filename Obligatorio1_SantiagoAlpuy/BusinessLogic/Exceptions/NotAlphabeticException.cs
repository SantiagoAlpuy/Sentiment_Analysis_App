using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class NotAlphabeticException : Exception
    {
        public NotAlphabeticException()
        {
        }

        public NotAlphabeticException(String message) : base(message)
        {

        }
    }
}
