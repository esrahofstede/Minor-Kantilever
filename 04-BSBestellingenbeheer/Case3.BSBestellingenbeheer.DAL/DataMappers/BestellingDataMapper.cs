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
    /// <summary>
    /// Bestelling mapper class which maps Bestellingen from the database
    /// </summary>
    public class BestellingDataMapper
    {
        /// <summary>
        /// Gets bestellingen entities from the database and returns the first
        /// </summary>
        /// <param name="context"></param>
        /// <returns>The first bestelling to pack</returns>
        public Bestelling GetBestellingToPack(BestellingContext context)
        {
            return context.Bestellingen.OrderBy(b => b.BestelDatum).Include(b => b.Artikelen).FirstOrDefault();
        }
    }
}
