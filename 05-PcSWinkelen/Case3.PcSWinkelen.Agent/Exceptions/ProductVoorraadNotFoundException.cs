using Case3.PcSWinkelen.Schema.FoutenNS;
using System;

namespace Case3.PcSWinkelen.Agent.Exceptions
{
    /// <summary>
    /// Exception which could be thrown when a ProductVoorraad is not found
    /// </summary>
    [Serializable]
    public class ProductVoorraadNotFoundException : Exception
    {
        public int Number { get; set; }
        public FoutErnst Serverity { get; set; }


        /// <summary>
        /// Creates a instance of the ProductVoorraadNotFoundException which is throwed when a product is not found when requesting the Voorraad
        /// </summary>
        /// <param name="source"></param>
        /// <param name="message"></param>
        /// <param name="number"></param>
        /// <param name="severity"></param>
        public ProductVoorraadNotFoundException(string source, string message, int number, FoutErnst severity) : base(message)
        {
            Source = source;
            Number = number;
            Serverity = severity;
        }

    }
}
