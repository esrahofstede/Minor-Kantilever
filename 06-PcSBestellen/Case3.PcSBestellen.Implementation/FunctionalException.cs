using System;
using System.Runtime.Serialization;

namespace Case3.PcSBestellen.Implementation
{
    [Serializable]
    internal class FunctionalException : Exception
    {
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