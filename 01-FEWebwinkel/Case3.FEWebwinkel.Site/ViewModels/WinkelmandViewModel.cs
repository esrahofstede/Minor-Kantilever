using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Case3.FEWebwinkel.Site.Models;

namespace Case3.FEWebwinkel.Site.Models
{
    public class WinkelmandViewModel
    {
        public List<ArtikelViewModel> Artikelen { get; set; }
        public decimal TotaalExclBTW { get; set; }
        public decimal TotaalInclBTW { get; set; }
        public decimal BTWPercentage { get; set; }
        public decimal TotaalBTW { get; set; }
    }
}