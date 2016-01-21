namespace Case3.BSBestellingenbeheer.Entities
{
    /// <summary>
    /// The artikel entity
    /// </summary>
    public class Artikel
    {
        public long ID { get; set; }

        public string Naam { get; set; }

        public int Aantal { get; set; }

        public string Leverancierscode { get; set; }

        public string Leverancier { get; set; }
    }
}