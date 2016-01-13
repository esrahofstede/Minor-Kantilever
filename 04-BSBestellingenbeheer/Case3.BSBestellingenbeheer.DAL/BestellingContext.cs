using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Case3.BSBestellingenbeheer.DAL
{
    public class BestellingContext : DbContext
    {
        public BestellingContext()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Artikel> Artikellen { get; set; }
    }
}
}
