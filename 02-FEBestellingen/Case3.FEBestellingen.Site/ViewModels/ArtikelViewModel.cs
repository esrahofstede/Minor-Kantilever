namespace Case3.FEBestellingen.Site.ViewModels
{
    /// <summary>
    /// The Artikel ViewModel
    /// </summary>
    public class ArtikelViewModel
    {
        public string Naam { get; set; }
        public string Leveranciersnaam { get; set; }
        public string Leverancierscode { get; set; }
        public int Aantal { get; set; }
        public decimal? Prijs { get; set; }
    }
}