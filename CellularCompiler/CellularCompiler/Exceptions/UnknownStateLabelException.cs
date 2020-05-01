using System;
using System.Runtime.Serialization;

namespace CellularCompiler.Exceptions
{
    internal class UnknownStateLabelException : Exception
    {
        public UnknownStateLabelException()
        {
        }

        public UnknownStateLabelException(string message) 
            : base(message)
        {
        }

        public UnknownStateLabelException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected UnknownStateLabelException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}