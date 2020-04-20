using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class ContainsNumbersException : Exception
    {
        public ContainsNumbersException() { }

        public ContainsNumbersException(string message)
            : base(message) { }
    }

}
