using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Site.Helpers;
using Case3.FEWebwinkel.Site.Models;
using Case3.FEWebwinkel.Site.ViewModels;

namespace Case3.FEWebwinkel.Site.Tests.Helpers
{
    /// <summary>
    /// Summary description for CookieHelperTest
    /// </summary>
    [TestClass]
    public class CookieHelperTest
    {
        [TestMethod]
        public void CreateArtikelViewModelFromCatalogusViewModelReturnsCorrectType()
        {
            // Arrange
            var helper = new CookieHelper();
            var dummy = new CatalogusViewModel
            {
                Naam = "fietsbel",
                Prijs = 2.0m,
            };

            // Act
            var result = helper.CreateArtikelViewModelFromCatalogusViewModel(dummy);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ArtikelViewModel));
        }

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void CreateArtikelViewModelFromCatalogusViewModelThrowsNullReferenceException()
        //{
        //    // Arrange
        //    var helper = new CookieHelper();

        //    // Act
        //    var result = helper.CreateArtikelViewModelFromCatalogusViewModel(null);

        //    // Assert
           
        //}

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateArtikelViewModelFromCatalogusViewModelThrowsNullReferenceException()
        {
            // Arrange
            var helper = new CookieHelper();
            var dummy = new CatalogusViewModel
            {
                Naam = null,
                Prijs = null,
            };

            // Act
            var result = helper.CreateArtikelViewModelFromCatalogusViewModel(dummy);

            // Assert

        }

        [TestMethod]
        public void CreateArtikelViewModelFromCatalogusViewModelReturnsCorrectData()
        {
            // Arrange
            var helper = new CookieHelper();
            var dummy = new CatalogusViewModel
            {
                Naam = "fietsbel",
                Prijs = 2.0m,
            };

            // Act
            var result = helper.CreateArtikelViewModelFromCatalogusViewModel(dummy);

            // Assert
            Assert.AreEqual(result.ArtikelNaam, "fietsbel");
            Assert.AreEqual(result.Prijs, 2.0m);
            Assert.AreEqual(result.Aantal, 1);

        }
    }
}
