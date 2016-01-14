using case3common.v1.faults;
using System;
using System.Runtime.Serialization;

namespace Case3.PcSWinkelen.Implementation
{
    [Serializable]
    internal class FunctionalException : Exception
    {
        public FunctionalErrorList Errors { get; set; }

        public FunctionalException()
        {
        }

        public FunctionalException(string message) : base(message)
        {
        }

        public FunctionalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FunctionalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}