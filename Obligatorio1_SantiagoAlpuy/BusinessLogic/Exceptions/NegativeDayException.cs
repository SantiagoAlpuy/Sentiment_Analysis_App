using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NegativeHourException : Exception
    {
        public NegativeHourException() { }
    }

}
