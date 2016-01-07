using System;

namespace Case3.FEWebwinkel.Site.ViewModels
{
    public class CatalogusViewModel
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public Decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public string Afbeeldingslocatie {
            get { return "../Content/Product_img/" + Afbeeldingslocatie; }
            set { Afbeeldingslocatie = value; } }
        public string Leverancier { get; set; }
    }
}