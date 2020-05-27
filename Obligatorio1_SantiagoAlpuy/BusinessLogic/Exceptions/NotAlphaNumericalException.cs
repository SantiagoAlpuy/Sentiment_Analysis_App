using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    public class NotAlphaNumericalException : Exception
    {
        public NotAlphaNumericalException()
        {
        }

        public NotAlphaNumericalException(String message) : base(message)
        {

        }
    }
}
