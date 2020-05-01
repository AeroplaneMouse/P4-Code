using System;
using System.Runtime.Serialization;

namespace CellularCompiler.Exceptions
{
    internal class InvalidRuleStatementContentException : Exception
    {
        public InvalidRuleStatementContentException()
        {
        }

        public InvalidRuleStatementContentException(string message) 
            : base(message)
        {
        }

        public InvalidRuleStatementContentException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidRuleStatementContentException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}