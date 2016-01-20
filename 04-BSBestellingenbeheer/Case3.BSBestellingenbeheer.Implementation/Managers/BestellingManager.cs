using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.BSBestellingenbeheer.DAL.Context;

namespace Case3.BSBestellingenbeheer.Implementation.Managers
{
    public class BestellingManager : IBestellingManager
    {
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
                    if(bestellingEntity.Artikelen != null && bestellingEntity.Artikelen.Count > 0)
                    {
                        foreach (Entities.Artikel artikel in bestellingEntity.Artikelen)
                        {
                            bestelling.Artikelen.Add(new BestelItem()
                            {
                                Product = new Product ()
                                {
                                    Naam = artikel.Naam,
                                    LeverancierNaam = artikel.Leverancier,
                                    Prijs = 5.00M,
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
