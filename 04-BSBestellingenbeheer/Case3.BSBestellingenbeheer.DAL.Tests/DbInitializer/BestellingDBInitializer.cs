﻿using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.DAL.Tests
{
    /// <summary>
    /// Deletes and recreates the database
    /// </summary>
    internal class BestellingDBInitializer : DropCreateDatabaseAlways<BestellingContext>
    {
        /// <summary>
        /// Seeds the database with data
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(BestellingContext context)
        {

            List<Artikel> lijst = new List<Artikel>();

            Artikel artikel1 = new Artikel()
            {
                ID = 1,
                Naam = "fietsbel",
                Leverancier = "gazelle",
                Leverancierscode = "03g54hbronlsfads",
                Prijs = 3.00M,
                Aantal = 3
            };

            Artikel artikel2 = new Artikel()
            {
                ID = 2,
                Naam = "remschijf",
                Leverancier = "gazelle",
                Leverancierscode = "oiaernglggafds234",
                Prijs = 3.00M,
                Aantal = 3
            };

            Artikel artikel3 = new Artikel()
            {
                ID = 3,
                Naam = "kantilever",
                Leverancier = "gazelle",
                Leverancierscode = "kvbaf9345245sda",
                Prijs = 3.00M,
                Aantal = 3
            };


            Artikel artikel4 = new Artikel()
            {
                ID = 4,
                Naam = "zadel",
                Leverancier = "gazelle",
                Leverancierscode = "vbsdaijgbreq6542",
                Prijs = 3.00M,
                Aantal = 3
            };

            lijst.Add(artikel1);
            lijst.Add(artikel2);
            lijst.Add(artikel3);
            lijst.Add(artikel4);

          
            

            List<Artikel> lijst2 = new List<Artikel>();

            Artikel artikel21 = new Artikel()
            {
                ID = 21,
                Naam = "fietsbel",
                Leverancier = "gazelle",
                Leverancierscode = "03g54hbronlsfads",
                Prijs = 4.00M,
                Aantal = 3
            };

            Artikel artikel22 = new Artikel()
            {
                ID = 22,
                Naam = "remschijf",
                Leverancier = "gazelle",
                Prijs = 4.00M,
                Leverancierscode = "oiaernglggafds234",
                Aantal = 3
            };

            Artikel artikel23 = new Artikel()
            {
                ID = 23,
                Naam = "kantilever",
                Leverancier = "gazelle",
                Prijs = 4.00M,
                Leverancierscode = "kvbaf9345245sda",
                Aantal = 3
            };


            Artikel artikel24 = new Artikel()
            {
                ID = 24,
                Naam = "zadel",
                Prijs = 4.00M,
                Leverancier = "gazelle",
                Leverancierscode = "vbsdaijgbreq6542",
                Aantal = 3
            };

            lijst2.Add(artikel21);
            lijst2.Add(artikel22);
            lijst2.Add(artikel23);
            lijst2.Add(artikel24);

            Bestelling a = new Bestelling()
            {
                ID = 1,
                BestelDatum = DateTime.Now,
                Status = 0,
                Artikelen = lijst,
                AdresRegel1 = "Hofmeesterij 89",
                KlantNaam = "Henk Jansen",
                Postcode = "6738PK",
                Woonplaats = "Veenendaal",
                BTWPercentage = 21,
                Telefoonnummer = "0654789542",
                AdresRegel2 = "8B"
            };

            Bestelling b = new Bestelling()
            {
                ID = 2,
                BestelDatum = DateTime.Now.AddDays(1),
                Status = 1,
                Artikelen = lijst2,
                AdresRegel1 = "Hofmeesterij 89",
                KlantNaam = "Henk Jansen",
                Postcode = "6738PK",
                Woonplaats = "Veenendaal",
                BTWPercentage = 21,
                Telefoonnummer = "0654789542",
            };

            context.Bestellingen.AddRange(new Bestelling[] { a, b });
            context.Artikelen.AddRange(new Artikel[] { artikel1, artikel2, artikel3, artikel4, artikel21, artikel22, artikel23, artikel24 });
            base.Seed(context);
        }
    }
}
