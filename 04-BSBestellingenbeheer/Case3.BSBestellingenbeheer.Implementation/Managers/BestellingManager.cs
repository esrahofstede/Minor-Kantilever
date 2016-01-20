using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.BSBestellingenbeheer.DAL.Context;
using System;
using System.Collections.Generic;

namespace Case3.BSBestellingenbeheer.Implementation.Managers
{
    public class BestellingManager : IBestellingManager
    {
        private IDataMapper<Entities.Bestelling, long> _bestellingDataMapper;

        public BestellingManager()
        {
            _bestellingDataMapper = new BestellingDataMapper();
        }

        public BestellingManager(IDataMapper<Entities.Bestelling, long> datamapper)
        {
            _bestellingDataMapper = datamapper;
        }

        public void InsertBestelling(Bestelling bestelling)
        {
            DateTime besteldatum = ParseBestelDatum(bestelling.FactuurDatum);
            try
            {
                Entities.Bestelling insertBestelling = new Entities.Bestelling()
                {
                    ID = (int)bestelling.BestellingID,
                    BestelDatum = besteldatum,
                    Status = (int)bestelling.Status,
                    KlantNaam = bestelling.Klantgegevens.Naam,
                    AdresRegel1 = bestelling.Klantgegevens.Adresregel1,
                    AdresRegel2 = bestelling.Klantgegevens.Adresregel2 ?? string.Empty,
                    Postcode = bestelling.Klantgegevens.Postcode,
                    Woonplaats = bestelling.Klantgegevens.Woonplaats,
                    Telefoonnummer = bestelling.Klantgegevens.Telefoonnummer,
                    Artikelen = new List<Entities.Artikel>(),
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
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private DateTime ParseBestelDatum(string factuurDatum)
        {
            DateTime result;
            try
            {
                DateTime.TryParse(factuurDatum, out result);
            }
            catch (Exception)
            {
                result = DateTime.Now;
            }
            return result;
        }

        /// <summary>
        /// This method returns the First bestelling to be packed.
        /// </summary>
        /// <returns>Bestelling to be packed</returns>
        public Bestelling FindFirstBestelling()
        {
            Bestelling bestelling = new Bestelling()
            {
                Artikelen = new Artikelen()
            };

            BestellingDataMapper bestellingDataMappper = new BestellingDataMapper();
            Entities.Bestelling bestellingEntity = null;
            using (var context = new BestellingContext())
            {
                bestellingEntity = bestellingDataMappper.GetBestellingToPack(context);
                if (bestellingEntity != null)
                {
                    if (bestellingEntity.Artikelen != null && bestellingEntity.Artikelen.Count > 0)
                    {
                        foreach (Entities.Artikel artikel in bestellingEntity.Artikelen)
                        {
                            bestelling.Artikelen.Add(new BestelItem()
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
                }
            }
            return bestelling;
        }


    }
}
