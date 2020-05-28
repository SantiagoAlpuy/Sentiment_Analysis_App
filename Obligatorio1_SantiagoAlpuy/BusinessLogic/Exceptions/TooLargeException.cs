using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class TooLargeException : Exception
    {
        public TooLargeException()
        {
        }

        public TooLargeException(String message) : base(message)
        {

        }
    }
}
