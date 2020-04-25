using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NegativeDayException : Exception
    {
        public NegativeDayException() { }
    }

}
