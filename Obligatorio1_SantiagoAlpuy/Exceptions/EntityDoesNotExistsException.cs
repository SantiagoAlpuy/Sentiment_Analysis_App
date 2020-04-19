using System;

namespace Exceptions
{
    [Serializable]
    public class EntityDoesNotExistsException : Exception
    {
        public EntityDoesNotExistsException() { }

        public EntityDoesNotExistsException(string message)
            : base(message) { }
    }
}
