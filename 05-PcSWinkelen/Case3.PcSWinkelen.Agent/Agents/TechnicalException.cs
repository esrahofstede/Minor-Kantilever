using System;
using System.Runtime.Serialization;

namespace Case3.PcSWinkelen.Agent.Agents
{
    [Serializable]
    class TechnicalException : Exception
    {
        public TechnicalException()
        {
        }

        public TechnicalException(string message) : base(message)
        {
        }

        public TechnicalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TechnicalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}