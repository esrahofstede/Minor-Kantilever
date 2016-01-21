using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using Case3.BSBestellingenbeheer.DAL.Exceptions;

namespace Case3.BSBestellingenbeheer.DAL.DataMappers
{
    /// <summary>
    /// Responsible for all CRUD actions for Bestellingen
    /// </summary>
    public class BestellingDataMapper : IDataMapper<Bestelling,long>
    {
        /// <summary>
        /// This method persists a bestelling entity. If the operation could not complete, an error is thrown.
        /// </summary>
        /// <param name="item">Bestelling entity</param>
        public void Insert(Bestelling item)
        {
            using (var context = new BestellingContext())
            {
                try
                {
                    context.Bestellingen.Add(item);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    throw new FunctionalException("De bestelling is niet van het juiste formaat. Opslaan is niet mogelijk.");
                }
                catch (Exception)
                {
                    throw new TechnicalException("Er is een technische fout opgetreden tijdens het toevoegen van de bestelling");
                }
            }
        }

        /// <summary>
        /// Gets one Bestelling where the status == 0 and ordered by BestelDatum. Method is virtual so that MoQ can override it
        /// </summary>
        /// <param name="context">BestellingContext</param>
        /// <returns>Bestelling</returns>
        public virtual Bestelling GetBestellingToPack()
        {
            using (var context = new BestellingContext())
            {
                try
                {
                    Bestelling bestellingtoPack = context.Bestellingen
                        .Where(b => b.Status == 0).OrderBy(b => b.BestelDatum)
                        .Include(b => b.Artikelen)
                        .FirstOrDefault();

                    if (bestellingtoPack == null)
                    {
                        throw new FunctionalException("Er kan geen nieuwe bestelling gevonden worden");
                    }

                    return bestellingtoPack;
                }
                catch (Exception)
                {
                    throw new TechnicalException("Er is een technische fout opgetreden tijdens het ophalen van de bestelling");
                }      
            }
        }

        /// <summary>
        /// Updates a Bestelling.Status to 1. Method is virtual so that MoQ can override it
        /// </summary>
        /// <param name="bestellingId">Id of the Bestelling</param>
        public virtual void UpdateBestellingStatusToPacked(long bestellingID)
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
                    return context.Bestellingen.Where(b => b.ID == bestellingID).Include(b => b.Artikelen).Single();
                }
                catch (InvalidOperationException)
                {
                    throw new FunctionalException("Bestelling niet gevonden");
                }
                catch (Exception)
                {
                    throw new TechnicalException("Er is een technische fout opgetreden tijdens het ophalen van de bestelling.");
                }
            }
        }
    }
}
