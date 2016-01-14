using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.DAL;
using Case3.BSCatalogusBeheer.Schema.ProductNS;

namespace Case3.BSBestellingenbeheer.Implementation.Managers
{
    public class BestellingManager : IBestellingManager
    {
        public Bestelling FindFirstBestelling()
        {

            Bestelling bestelling = new Bestelling();

            BestellingDataMapper bestellingDataMappper = new BestellingDataMapper();

            Entities.Bestelling bestellingEntity = null;

            using (var context = new BestellingContext())
            {
                bestellingEntity = bestellingDataMappper.GetBestellingToPack(context);
            }
            
            if (bestellingEntity != null)
            {
                if(bestellingEntity.Artikelen.Count > 0)
                {
                    foreach (Entities.Artikel artikel in bestellingEntity.Artikelen)
                    {
                        bestelling.Artikelen.Add(new BestelItem()
                        {
                            Product = new Product ()
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

            return bestelling;
        }
    }
}
