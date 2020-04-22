using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NegativePostCountException : Exception
    {
        public NegativePostCountException() { }

        public NegativePostCountException(string message)
            : base(message) { }
    }

}
