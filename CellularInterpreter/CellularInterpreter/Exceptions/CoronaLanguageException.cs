using System;

namespace CellularInterpreter.Exceptions
{
    class CoronaLanguageException : Exception
    {
        public CoronaLanguageException(string message)
            : base(message)
        { }

        public CoronaLanguageException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
