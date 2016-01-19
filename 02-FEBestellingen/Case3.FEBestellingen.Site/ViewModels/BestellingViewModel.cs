using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Case3.FEBestellingen.Site.ViewModels
{
    /// <summary>
    /// The Bestelling ViewModel
    /// </summary>
    public class BestellingViewModel
    {
        public List<ArtikelViewModel> Artikelen { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FactuurDatum { get; set; }
        public int FactuurNummer { get; set; }
        public decimal TotaalExclBTW { get; set; }
        public decimal TotaalInclBTW { get; set; }
        public decimal BTWPercentage { get; set; }
        public decimal TotaalBTW { get; set; }

        //Klant information
        public string KlantNaam { get; set; }
        public string Adresregel1 { get; set; }
        public string Adresregel2 { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
    }
}