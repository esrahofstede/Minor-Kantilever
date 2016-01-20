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
        public Bestelling ConvertBestellingEntityToDTO(Entities.Bestelling bestellingEntity)
        {

            Bestelling bestellingDTO = new Bestelling()
            {
                Artikelen = new Artikelen(),
                BestellingID = (int)bestellingEntity.ID,
                FactuurDatum = bestellingEntity.BestelDatum.ToString()
                
            };

            if (bestellingEntity != null)
            {
                if(bestellingEntity.Artikelen != null && bestellingEntity.Artikelen.Count > 0)
                {
                    foreach (Entities.Artikel artikel in bestellingEntity.Artikelen)
                    {
                        bestellingDTO.Artikelen.Add(new BestelItem()
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
        
        return bestellingDTO;

        }
    }
}
