using case3common.v1.faults;
using System;
using System.Runtime.Serialization;

namespace Case3.PcSWinkelen.Agent.Agents
{
    [DataContract]
    public class TechnicalException : Exception
    {
        [DataMember]
        public ErrorList Errors { get; set; }

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