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
    /// Responsible for all CRUD actions for Bestellingen
    /// </summary>
    public class BestellingDataMapper
    {

        /// <summary>
        /// Gets one Bestelling where the status == 0 and ordered by BestelDatum
        /// </summary>
        /// <param name="context">BestellingContext</param>
        /// <returns>Bestelling</returns>
        public Bestelling GetBestellingToPack(BestellingContext context)
        {
            return context.Bestellingen.Where(b => b.Status == 0).OrderBy(b => b.BestelDatum).Include(b => b.Artikelen).FirstOrDefault();
        }

        /// <summary>
        /// Updates a Bestelling.Status to 1
        /// </summary>
        /// <param name="bestellingId">Id of the Bestelling</param>
        public void UpdateBestellingStatusToPacked(long bestellingID)
        {
            using (var context = new BestellingContext())
            {
                Bestelling bestellingToUpdate = FindBestellingByID(bestellingID);

                bestellingToUpdate.Status = 1;

                context.Bestellingen.Attach(bestellingToUpdate);
                context.Entry(bestellingToUpdate).Property(b => b.Status).IsModified = true;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get Bestelling based on ID
        /// </summary>
        /// <param name="bestellingID">(long) bestellingID</param>
        /// <returns>Bestelling</returns>
        public Bestelling FindBestellingByID(long bestellingID)
        {
            using (var context = new BestellingContext())
            {
                try
                {
                    return context.Bestellingen.Where(b => b.ID == bestellingID).Include(b => b.Artikelen).SingleOrDefault();
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException("Bestelling niet gevonden");
                }
            }
        }
    }
}
