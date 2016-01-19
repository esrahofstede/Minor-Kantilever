namespace Case3.FEWebwinkel.Site.ViewModels
{
    /// <summary>
    /// This is the ArtikelViewModel used for displaying the Artikelen in the Winkelmand
    /// </summary>
    public class ArtikelViewModel
    {
        public int? ID { get; set; }
        public string ArtikelNaam { get; set; }
        public decimal Prijs { get; set; }
        public int Aantal { get; set; }
    }
}