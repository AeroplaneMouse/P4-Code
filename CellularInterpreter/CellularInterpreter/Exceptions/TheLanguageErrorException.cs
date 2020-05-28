using System;

namespace CI.Exceptions
{
    class TheLanguageErrorException : Exception
    {
        public TheLanguageErrorException(string message)
            : base(message)
        { }

        public TheLanguageErrorException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
