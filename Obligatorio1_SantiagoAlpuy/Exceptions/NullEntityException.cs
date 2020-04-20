using System;

namespace Exceptions
{
    [Serializable]
    public class NullEntityException : Exception
    {
        public NullEntityException() { }

        public NullEntityException(string message)
            : base(message) { }
    }

}
