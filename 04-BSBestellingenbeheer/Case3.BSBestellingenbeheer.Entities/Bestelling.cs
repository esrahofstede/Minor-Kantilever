using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.Entities
{
    /// <summary>
    /// The bestelling entity
    /// </summary>
    public class Bestelling
    {
        public long ID { get; set; }

        public DateTime BestelDatum { get; set; }

        public int Status { get; set; }

        public virtual List<Artikel> Artikelen { get; set; }

        public int BTWPercentage { get; set; }

        public string KlantNaam { get; set; }

        public string AdresRegel1 { get; set; }

        public string AdresRegel2 { get; set; }

        public string Postcode { get; set; }

        public string Woonplaats { get; set; }

        public string Telefoonnummer { get; set; }
    }
}
