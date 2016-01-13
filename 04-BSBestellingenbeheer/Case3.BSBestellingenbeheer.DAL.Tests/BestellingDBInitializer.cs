using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.DAL.Tests
{
    internal class BestellingDBInitializer : DropCreateDatabaseAlways<BestellingContext>
    {
        protected override void Seed(BestellingContext context)
        {

            List<Artikel> lijst = new List<Artikel>();

            Artikel artikel1 = new Artikel()
            {
                ID = 1,
                Naam = "fietsbel",
                Leverancier = "gazelle",
                Leverancierscode = "03g54hbronlsfads",
                Aantal = 3
            };

            Artikel artikel2 = new Artikel()
            {
                ID = 2,
                Naam = "remschijf",
                Leverancier = "gazelle",
                Leverancierscode = "oiaernglggafds234",
                Aantal = 3
            };

            Artikel artikel3 = new Artikel()
            {
                ID = 3,
                Naam = "kantilever",
                Leverancier = "gazelle",
                Leverancierscode = "kvbaf9345245sda",
                Aantal = 3
            };


            Artikel artikel4 = new Artikel()
            {
                ID = 4,
                Naam = "zadel",
                Leverancier = "gazelle",
                Leverancierscode = "vbsdaijgbreq6542",
                Aantal = 3
            };

            lijst.Add(artikel1);
            lijst.Add(artikel2);
            lijst.Add(artikel3);
            lijst.Add(artikel4);

            Bestelling a = new Bestelling()
            {
                ID = 1,
                BestelDatum = new DateTime(),
                Artikellen = lijst,
            };

            Bestelling b = new Bestelling()
            {
                ID = 2,
                BestelDatum = new DateTime(),
                Artikellen = lijst,
            };

            context.Bestellingen.AddRange(new Bestelling[] { a, b });
            context.Artikellen.AddRange(new Artikel[] { artikel1, artikel2, artikel3, artikel4 });

            base.Seed(context);
        }
    }
}
