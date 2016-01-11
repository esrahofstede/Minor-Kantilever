using System;
using System.Runtime.Serialization;
using case3common.v1.faults;

namespace Case3.PcSBestellen.Implementation
{
    [Serializable]
    public class FunctionalException : Exception
    {
        private FunctionalErrorList _list;

        public FunctionalException()
        {
        }

        public FunctionalException(string message) : base(message)
        {
        }

        public FunctionalException(string message, FunctionalErrorList errorList) : base(message)
        {
            _list = errorList;
        }

        public FunctionalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FunctionalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}