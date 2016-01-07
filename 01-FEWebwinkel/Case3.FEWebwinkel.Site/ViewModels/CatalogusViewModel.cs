using System;

namespace Case3.FEWebwinkel.Site.ViewModels
{
    public class CatalogusViewModel
    {
        public int? ID { get; set; }
        public string Naam { get; set; }
        public decimal? Prijs { get; set; }
        public int Voorraad { get; set; }
        public string Afbeeldingslocatie {  get; set; }
        public string Leverancier { get; set; }
    }
}