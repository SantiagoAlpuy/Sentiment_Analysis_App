using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NullEntityException : Exception
    {
        public NullEntityException() { }
    }

}
