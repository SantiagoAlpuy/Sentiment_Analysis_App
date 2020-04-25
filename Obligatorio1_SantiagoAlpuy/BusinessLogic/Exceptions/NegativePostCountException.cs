using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NegativePostCountException : Exception
    {
        public NegativePostCountException() { }
    }

}
