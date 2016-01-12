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
        /// <summary>
        /// Creates an ArtikelViewModel with the data from a CatalogusViewModel
        /// </summary>
        /// <param name="catalogusArtikel">The CatalogusViewModel with the data you want to fill your ArtikelViewModel with</param>
        /// <returns>An ArtikelViewModel object</returns>
        public ArtikelViewModel CreateArtikelViewModelFromCatalogusViewModel(CatalogusViewModel catalogusArtikel)
        {
            try
            {
                return new ArtikelViewModel
                {
                    ID = catalogusArtikel.ID,
                    ArtikelNaam = catalogusArtikel.Naam,
                    Aantal = 1,
                    Prijs = catalogusArtikel.Prijs.GetValueOrDefault()
                    
                };
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates a cookie with a list of ArtikelViewModels
        /// </summary>
        /// <param name="artikelLijst">A list of ArtikelViewModels</param>
        public void CreateCookieWithArtikellijst(List<ArtikelViewModel> artikelLijst)
        {
            string MyJsonObject = new JavaScriptSerializer().Serialize(artikelLijst);
            var cookie = new HttpCookie("artikelen", MyJsonObject)
            {
                Expires = DateTime.Now.AddYears(1)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}