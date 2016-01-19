using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.DAL.DataMappers
{
    public class BestellingDataMapper
    {

        public Bestelling GetBestellingToPack(BestellingContext context)
        {
            return context.Bestellingen.Where(b => b.Status == 0).OrderBy(b => b.BestelDatum).Include(b => b.Artikelen).FirstOrDefault();
        }
    }
}
