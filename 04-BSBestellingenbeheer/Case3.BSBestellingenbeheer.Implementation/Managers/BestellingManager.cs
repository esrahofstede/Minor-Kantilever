using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using System;
using System.Collections.Generic;
using Case3.BSBestellingenbeheer.DAL.Exceptions;

namespace Case3.BSBestellingenbeheer.Implementation.Managers
{
    /// <summary>
    /// This class is responsible for mapping Bestelling DTO's to Bestelling entities and putting them together if necessary.
    /// </summary>
    public class BestellingManager : IBestellingManager
    {
        private IDataMapper<Entities.Bestelling, long> _bestellingDataMapper;

        /// <summary>
        /// Constructor for the manager. Uses the BestellingDataMapper default. 
        /// </summary>
        public BestellingManager()
        {
            _bestellingDataMapper = new BestellingDataMapper();
        }

        /// <summary>
        /// Constructor for testing purposes.
        /// </summary>
        /// <param name="dataMapper">The datamapper to use</param>
        public BestellingManager(IDataMapper<Entities.Bestelling, long> dataMapper)
        {
            _bestellingDataMapper = dataMapper;
        }

        /// <summary>
        /// This method maps a Bestelling DTO to a Bestelling Entity, and uses the BestellingDatamapper to persist.
        /// </summary>
        /// <param name="bestelling">Bestelling DTO</param>
        public void InsertBestelling(Bestelling bestelling)
        {
            if (bestelling != null)
            {
                DateTime besteldatum = ParseBestelDatum(bestelling.FactuurDatum);
                try
                {
                    Entities.Bestelling insertBestelling = new Entities.Bestelling()
                    {
                        BestelDatum = besteldatum,
                        Status = 0, //Status: Besteld
                        KlantNaam = bestelling.Klantgegevens.Naam,
                        AdresRegel1 = bestelling.Klantgegevens.Adresregel1,
                        AdresRegel2 = bestelling.Klantgegevens.Adresregel2,
                        Postcode = bestelling.Klantgegevens.Postcode,
                        Woonplaats = bestelling.Klantgegevens.Woonplaats,
                        Telefoonnummer = bestelling.Klantgegevens.Telefoonnummer,
                        Artikelen = new List<Entities.Artikel>(),
                        BTWPercentage = (int)bestelling.BTWPercentage,
                    };

                    foreach (var item in bestelling.Artikelen)
                    {
                        insertBestelling.Artikelen.Add(new Entities.Artikel()
                        {
                            ID = (long)item.Product.Id,
                            Naam = item.Product.Naam,
                            Leverancier = item.Product.LeverancierNaam,
                            Leverancierscode = item.Product.LeveranciersProductId,
                            Aantal = item.Aantal
                        });
                    }
                    _bestellingDataMapper.Insert(insertBestelling);
                }

                catch (InvalidOperationException)
                {
                    throw new FunctionalException("De opgegeven bestelling is niet in het juiste formaat.");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// This method parses a string to a DateTime. If not possible, use the current DateTime.
        /// </summary>
        /// <param name="factuurDatum">date as a string</param>
        /// <returns>Datetime</returns>
        private static DateTime ParseBestelDatum(string factuurDatum)
        {
            DateTime result;
            if (DateTime.TryParse(factuurDatum, out result))
            {
                return result;
            }
            else
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Converts a bestelling entity to a DTO
        /// </summary>
        /// <param name="bestellingEntity">the entity to convert</param>
        /// <returns></returns>
        public virtual Bestelling ConvertBestellingEntityToDTO(Entities.Bestelling bestellingEntity)
        {
            if (bestellingEntity != null)
            {
                Bestelling bestellingDTO = new Bestelling()
                {
                    Artikelen = new Artikelen(),
                    BestellingID = (int)bestellingEntity.ID,
                    FactuurDatum = bestellingEntity.BestelDatum.ToString()

                };

                if (bestellingEntity.Artikelen != null && bestellingEntity.Artikelen.Count > 0)
                {
                    foreach (Entities.Artikel artikel in bestellingEntity.Artikelen)
                    {
                        bestellingDTO.Artikelen.Add(new BestelItem()
                        {

                            Product = new Product()
                            {
                                Naam = artikel.Naam,
                                LeverancierNaam = artikel.Leverancier,
                                LeveranciersProductId = artikel.Leverancierscode,
                            },
                            Aantal = artikel.Aantal
                        });
                    }
                }
                return bestellingDTO;
            }
            return null;
        }
    }
}

