using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.DAL.Mappings
{
    /// <summary>
    /// Database mapper class to map the WinkelmandItem entity to the database
    /// </summary>
    public class WinkelmandItemMapping : EntityTypeConfiguration<WinkelmandItem>
    {
        public WinkelmandItemMapping()
        {
            this.ToTable("WinkelmandItem");

            this.HasKey(k => k.ID);

            this.Property(k => k.SessieID)
                .IsRequired();

            this.Property(k => k.LeveranciersProductId)
                .IsRequired();

            this.Property(k => k.SessieID)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("IX_Sessie") { IsUnique = false }));

            this.Property(k => k.Naam)
                .HasMaxLength(200);

            this.Property(k => k.SessieID)
                .HasMaxLength(100);

            this.Property(k => k.LeverancierNaam)
                .HasMaxLength(100);

            this.Property(k => k.LeveranciersProductId)
                .HasMaxLength(100);
        }
    }
}
