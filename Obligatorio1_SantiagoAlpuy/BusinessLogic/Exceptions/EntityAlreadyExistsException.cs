using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() { }
    }
}
