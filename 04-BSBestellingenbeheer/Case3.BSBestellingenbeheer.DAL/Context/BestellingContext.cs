using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Case3.BSBestellingenbeheer.DAL.Mappings;

namespace Case3.BSBestellingenbeheer.DAL.Context
{
    /// <summary>
    /// Class for connectin the bestelling database
    /// </summary>
    public class BestellingContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BestellingContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Artikel> Artikelen { get; set; }

        /// <summary>
        /// Model creating method
        /// </summary>
        /// <param name="modelBuilder">The modelbuilder is used for creating the tables</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Bestelling>(new BestellingMapping());
            modelBuilder.Configurations.Add<Artikel>(new ArtikelMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

