using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.DAL.Mappings
{
    class ArtikelMapping : EntityTypeConfiguration<Artikel>
    {
        public ArtikelMapping()
        {
            this.ToTable("Artikel");

            this.HasKey(a => a.ID);

            this.Property(b => b.Naam)
                .HasColumnName("naam");
        }

    }
}
