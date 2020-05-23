using System;
using System.Runtime.Serialization;

namespace CI.Exceptions
{
    internal class InvalidMatchStatementContentException : Exception
    {
        public InvalidMatchStatementContentException()
        {
        }

        public InvalidMatchStatementContentException(string message) 
            : base(message)
        {
        }

        public InvalidMatchStatementContentException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidMatchStatementContentException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}