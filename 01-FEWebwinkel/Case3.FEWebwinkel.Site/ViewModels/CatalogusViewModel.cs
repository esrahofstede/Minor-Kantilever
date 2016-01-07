using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case3.FEWebwinkel.Site.ViewModels
{
    public class CatalogusViewModel
    {
        public string Naam { get; set; }
        public Decimal Prijs { get; set; }
        public int Voorraad { get; set; }
        public string Afbeelding { get; set; }
    }
}