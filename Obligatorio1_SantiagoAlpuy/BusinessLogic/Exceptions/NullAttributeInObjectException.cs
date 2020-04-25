using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NullAttributeInObjectException : Exception
    {
        public NullAttributeInObjectException() { }
    }

}
