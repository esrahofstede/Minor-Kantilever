namespace Case3.FEBestellingen.Site.ViewModels
{
    /// <summary>
    /// The Artikel ViewModel
    /// </summary>
    public class ArtikelViewModel
    {

        public int? ID { get; set; }
        public string ArtikelNaam { get; set; }
        public decimal? Prijs { get; set; }
        public int Aantal { get; set; }
        public string Leveranciersnaam { get; set; }
        public string Leverancierscode { get; set; }

    }
}