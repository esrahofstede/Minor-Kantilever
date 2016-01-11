

using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.Models;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.Tests.Mocks
{
    public class CookieNatorArtikelenMock<T> : ICookieNator<T>
    {
        public List<T> GetCookieValue(string cookieName)
        {

            /*List<ArtikelViewModel> artikelList = new List<ArtikelViewModel>();

            artikelList.Add(new ArtikelViewModel() {
                
            });
            */


            /*r artikel1 = new ArtikelViewModel
            {
                ArtikelNaam = "Fietsbel",
                Aantal = 2,
                Prijs = 4.95M,
            };

            artikelList.Add(new ArtikelViewModel()
            {
                ID = 1,
                Aantal = 1,
                Prijs = 10.00M,
                ArtikelNaam = "TestProduct 1"
            });*/
            /*new ArtikelViewModel()
                {
                    ID = 1,
                    Aantal = 1,
                    Prijs = 10.00M,
                    ArtikelNaam = "TestProduct 1"
                },
                new ArtikelViewModel()
                {
                    ID = 2,
                    Aantal = 2,
                    Prijs = 20.00M,
                    ArtikelNaam = "TestProduct 2"
                },
                new ArtikelViewModel()
                {
                    ID = 3,
                    Aantal = 3,
                    Prijs = 30.00M,
                    ArtikelNaam = "TestProduct 3"
                },
                new ArtikelViewModel()
                {
                    ID = 4,
                    Aantal = 4,
                    Prijs = 40.00M,
                    ArtikelNaam = "TestProduct 4"
                },
                new ArtikelViewModel()
                {
                    ID = 5,
                    Aantal = 5,
                    Prijs = 50.00M,
                    ArtikelNaam = "TestProduct 5"
                },*/

            return null;    
        }

    }
}
