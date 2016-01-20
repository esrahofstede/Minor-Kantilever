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
    /// Mapping class for the Artikel entity
    /// </summary>
    public class ArtikelMapping : EntityTypeConfiguration<Artikel>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ArtikelMapping()
        {
            this.ToTable("Artikel");

            this.HasKey(a => a.ID);

            this.Property(b => b.Naam)
            .HasMaxLength(150)
            .HasColumnName("Naam")
            .IsRequired();

            this.Property(p => p.Leverancier)
            .HasMaxLength(250)
            .HasColumnName("Leverancier")
            .IsRequired();

            this.Property(p => p.Leverancierscode)
            .HasMaxLength(150)
            .HasColumnName("Leverancierscode")
            .IsRequired();
        }

    }
}
