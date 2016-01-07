using Case3.PcSWinkelen.Schema.Fouten;
using System;


namespace Case3.PcSWinkelen.Agent.Exceptions
{
    public class ProductVoorraadNotFoundException : Exception
    {
        public override string Source { get; set; }
        public override string Message { get; }
        public int Number { get; set; }
        public FoutErnst Serverity { get; set; }

        public ProductVoorraadNotFoundException(string source, string message, int number, FoutErnst severity)
        {
            Source = source;
            Message = message;
            Number = number;
            Serverity = severity;
        }
    }
}
