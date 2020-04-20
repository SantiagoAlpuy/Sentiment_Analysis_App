using System;

namespace Exceptions
{
    [Serializable]
    public class ContainsNumbersException : Exception
    {
        public ContainsNumbersException() { }

        public ContainsNumbersException(string message)
            : base(message) { }
    }

}
