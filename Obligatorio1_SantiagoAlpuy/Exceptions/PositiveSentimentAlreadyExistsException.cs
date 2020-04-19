using System;

namespace Exceptions
{
    [Serializable]
    public class PositiveSentimentAlreadyExistsException : Exception
    {
        public PositiveSentimentAlreadyExistsException() { }

        public PositiveSentimentAlreadyExistsException(string message)
            : base(message) { }
    }

    class SerializableAttribute : Attribute
    {
    }
}
