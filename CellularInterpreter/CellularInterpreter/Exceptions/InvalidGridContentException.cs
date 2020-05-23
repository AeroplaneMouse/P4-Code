using System;
using System.Runtime.Serialization;

namespace CI.Exceptions
{
    class InvalidGridContentException : Exception
    {
        public InvalidGridContentException()
        {
        }

        public InvalidGridContentException(string message) : base(message)
        {
        }

        public InvalidGridContentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGridContentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}