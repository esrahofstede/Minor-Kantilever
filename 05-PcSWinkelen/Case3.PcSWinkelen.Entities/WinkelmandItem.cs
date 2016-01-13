using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Entities
{
    public class WinkelmandItem
    {
        public long ID { get; set; }
        public int? ProductID { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public string LeveranciersProductId { get; set; }
        public string LeverancierNaam { get; set; }
        public int Aantal { get; set; }
        public string SessieID { get; set; }
        
    }
}
