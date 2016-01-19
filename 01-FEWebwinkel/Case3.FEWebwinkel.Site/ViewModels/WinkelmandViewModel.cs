using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.ViewModels
{
    /// <summary>
    /// This is the WinkelmandViewModel used for displaying the Winkelmand
    /// </summary>
    public class WinkelmandViewModel
    {
        public List<ArtikelViewModel> Artikelen { get; set; }
        public decimal TotaalExclBTW { get; set; }
        public decimal TotaalInclBTW { get; set; }
        public decimal BTWPercentage { get; set; }
        public decimal TotaalBTW { get; set; }
    }
}