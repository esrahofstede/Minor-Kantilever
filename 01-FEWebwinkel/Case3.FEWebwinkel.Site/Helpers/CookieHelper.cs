using Case3.FEWebwinkel.Site.Models;
using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Case3.FEWebwinkel.Site.Helpers
{
    public class CookieHelper
    {

        public ArtikelViewModel CreateArtikelViewModelFromCatalogusViewModel(CatalogusViewModel catalogusArtikel)
        {
            try
            {
                return new ArtikelViewModel
                {
                    ArtikelNaam = catalogusArtikel.Naam,
                    Aantal = 1,
                    Prijs = catalogusArtikel.Prijs.GetValueOrDefault(),
                };
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        public void CreateCookieWithArtikellijst(List<ArtikelViewModel> artikelLijst)
        {
            string MyJsonObject = new JavaScriptSerializer().Serialize(artikelLijst);
            var cookie = new HttpCookie("artikelen", MyJsonObject)
            {
                Expires = DateTime.Now.AddYears(1)
            };

            //HttpContext.Response.Cookies.Add(cookie);
        }
    }
}