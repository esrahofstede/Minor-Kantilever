using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using case3common.v1.faults;

namespace Case3.PcSBestellen.Agent.Exceptions
{
    /// <summary>
    /// Custom TechnicalException for throwing exceptions with WCF
    /// </summary>
    [DataContract]
    public class TechnicalException : Exception
    {
        [DataMember]
        public ErrorLijst Errors { get; set; }

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
