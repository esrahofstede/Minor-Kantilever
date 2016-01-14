using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.DAL
{
    public class BestellingDataMapper
    {
        public void Insert(Bestelling bestelling)
        {
            using (var context = new BestellingContext())
            {
                context.Bestellingen.Add(bestelling);
                context.SaveChanges();
            }
        }

        public Bestelling GetBestellingToPack(BestellingContext context)
        {
            return context.Bestellingen.OrderBy(b => b.BestelDatum).FirstOrDefault();
        }
    }
}
