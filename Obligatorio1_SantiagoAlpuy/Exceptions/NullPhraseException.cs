﻿using System;

namespace Exceptions
{
    [Serializable]
    public class NullPhraseException : Exception
    {
        public NullPhraseException() { }

        public NullPhraseException(string message)
            : base(message) { }
    }

}
