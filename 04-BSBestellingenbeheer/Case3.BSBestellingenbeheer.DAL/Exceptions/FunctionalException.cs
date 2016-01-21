using System;
using System.Runtime.Serialization;

namespace Case3.BSBestellingenbeheer.DAL.Exceptions
{
    /// <summary>
    /// This class represents an exception where the user's input is not valid.
    /// </summary>
    [Serializable]
    
    public class FunctionalException : Exception
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