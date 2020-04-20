using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class EntityDoesNotExistsException : Exception
    {
        public EntityDoesNotExistsException() { }

        public EntityDoesNotExistsException(string message)
            : base(message) { }
    }
}
