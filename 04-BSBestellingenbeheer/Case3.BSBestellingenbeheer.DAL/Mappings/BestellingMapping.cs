using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.DAL.Mappings
{
    /// <summary>
    /// Mapping class for the Bestelling entity
    /// </summary>
    public class BestellingMapping : EntityTypeConfiguration<Bestelling>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BestellingMapping()
        {
            this.ToTable("Bestelling");

            this.HasKey(b => b.ID);

            this.Property(b => b.BestelDatum)
                .HasColumnName("bestelDatum");

            this.HasMany(b => b.Artikelen);
        }

    }
}
