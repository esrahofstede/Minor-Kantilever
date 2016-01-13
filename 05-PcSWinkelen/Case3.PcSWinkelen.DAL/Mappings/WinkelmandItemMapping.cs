﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Entities;

namespace Case3.PcSWinkelen.DAL.Mappings
{
    public class WinkelmandItemMapping : EntityTypeConfiguration<WinkelmandItem>
    {
        public WinkelmandItemMapping()
        {
            this.ToTable("WinkelmandItem");

            this.HasKey(k => k.ID);

            this.Property(k => k.ID)
                .IsRequired();

            this.Property(k => k.SessieID)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("IX_Sessie") { IsUnique = false }));

            this.Property(k => k.Naam)
                .HasMaxLength(200);
        }
    }
}
