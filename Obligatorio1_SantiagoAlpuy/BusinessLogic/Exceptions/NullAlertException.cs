using System;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class NullAlertException : Exception
    {
        public NullAlertException() { }
    }

}
