﻿using System;

namespace Exceptions
{
    [Serializable]
    public class NullAttributeInObjectException : Exception
    {
        public NullAttributeInObjectException() { }

        public NullAttributeInObjectException(string message)
            : base(message) { }
    }

}
