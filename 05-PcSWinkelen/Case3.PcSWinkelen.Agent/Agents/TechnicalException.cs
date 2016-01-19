using Case3.Common.Faults;
using System;
using System.Runtime.Serialization;

namespace Case3.PcSWinkelen.Agent.Agents
{
    [DataContract]
    public class TechnicalException : Exception
    {
        [DataMember]
        public ErrorLijst Errors { get; }

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