using Case3.PcSWinkelen.Schema.Fouten;
using System;


namespace Case3.PcSWinkelen.Agent.Exceptions
{
    [Serializable]
    public class ProductVoorraadNotFoundException : Exception
    {
        public int Number { get; set; }
        public FoutErnst Serverity { get; set; }


        public ProductVoorraadNotFoundException(string source, string message, int number, FoutErnst severity) : base(message)
        {
            Source = source;
            Number = number;
            Serverity = severity;
        }

    }
}
