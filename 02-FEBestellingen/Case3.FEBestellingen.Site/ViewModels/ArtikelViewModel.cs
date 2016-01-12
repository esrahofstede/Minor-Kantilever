using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case3.FEBestellingen.Site.ViewModels
{
    public class ArtikelViewModel
    {
        public string Naam { get; set; }
        public string Leveranciersnaam { get; set; }
        public string Leverancierscode { get; set; }
        public int Aantal { get; set; }
    }
}