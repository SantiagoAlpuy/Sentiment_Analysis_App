using System;

namespace Exceptions
{
    [Serializable]
    public class NullParameterException : Exception
    {
        public NullParameterException() { }

        public NullParameterException(string message)
            : base(message) { }
    }

}
