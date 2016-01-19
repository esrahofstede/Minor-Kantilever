namespace Case3.FEWebwinkel.Site.ViewModels
{
    /// <summary>
    /// This is the CatalogusViewModel used for displaying the Catalogus, this is one of the many elements
    /// </summary>
    public class CatalogusViewModel
    {
        public int? ID { get; set; }
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public int Voorraad { get; set; }
        public string Afbeeldingslocatie { get; set; }
        public string Leverancier { get; set; }
    }
}