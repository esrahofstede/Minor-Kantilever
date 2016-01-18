using Case3.FEWebwinkel.Site.Controllers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Tests.Controllers
{
    /// <summary>
    /// Responsible for testing the WinkelmandController Class
    /// </summary>
    [TestClass]
    public class WinkelmandControllerTest
    {
        #region -------[Support functions for tests]-------
        private static WinkelmandViewModel CreateWinkelmandViewModel()
        {
            return new WinkelmandViewModel
            {
                Artikelen = new List<ArtikelViewModel>()
                {
                    new ArtikelViewModel
                    {
                        ID = 1,
                        ArtikelNaam = "Fietsbel",
                        Prijs = 5.99M,
                        Aantal = 2,
                    },

                    new ArtikelViewModel
                    {
                        ID = 2,
                        ArtikelNaam = "Zadelpen",
                        Prijs = 15.12M,
                        Aantal = 1,
                    },
                },
                BTWPercentage = 21M,
                TotaalBTW = 21M,
                TotaalExclBTW = 100M,
                TotaalInclBTW = 121M,
            };
        }
        #endregion
        #region -------[Test for the index action]-------
        [TestMethod]
        public void WinkelmandControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var winkelmandViewModel = CreateWinkelmandViewModel();
            var mock = new Mock<IWinkelmandManager>(MockBehavior.Strict);
            mock.Setup(wm => wm.GetWinkelmand(It.IsAny<string>())).Returns(winkelmandViewModel);

            var controller = new WinkelmandController(mock.Object);
            //var controller = new WinkelmandController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void WinkelmandControllerIndexActionHasCorrectModel()
        {
            // Arrange
            var winkelmandViewModel = CreateWinkelmandViewModel();
            var mock = new Mock<IWinkelmandManager>(MockBehavior.Strict);
            mock.Setup(wm => wm.GetWinkelmand(It.IsAny<string>())).Returns(winkelmandViewModel);

            var controller = new WinkelmandController(mock.Object);


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(WinkelmandViewModel));
        }

        [TestMethod]
        public void WinkelmandControllerIndexActionModelHasCorrectData()
        {
            // Arrange
            var artikelList = CreateWinkelmandViewModel();
            var mock = new Mock<IWinkelmandManager>(MockBehavior.Strict);
            mock.Setup(wm => wm.GetWinkelmand(It.IsAny<string>())).Returns(artikelList);

            var controller = new WinkelmandController(mock.Object);


            // Act
            ViewResult result = controller.Index() as ViewResult;
            WinkelmandViewModel modelResult = (WinkelmandViewModel)result.Model;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(WinkelmandViewModel));
            Assert.AreEqual(2, modelResult.Artikelen.Count);
            //First Artikel
            Assert.AreEqual(1, modelResult.Artikelen[0].ID);
            Assert.AreEqual("Fietsbel", modelResult.Artikelen[0].ArtikelNaam);
            Assert.AreEqual(5.99M, modelResult.Artikelen[0].Prijs);
            Assert.AreEqual(2, modelResult.Artikelen[0].Aantal);
            //Second Artikel
            Assert.AreEqual(2, modelResult.Artikelen[1].ID);
            Assert.AreEqual("Zadelpen", modelResult.Artikelen[1].ArtikelNaam);
            Assert.AreEqual(15.12M, modelResult.Artikelen[1].Prijs);
            Assert.AreEqual(1, modelResult.Artikelen[1].Aantal);
            //Other Data from WinkelmandViewModel
            Assert.AreEqual(121M, modelResult.TotaalInclBTW);
            Assert.AreEqual(100M, modelResult.TotaalExclBTW);
            Assert.AreEqual(21, modelResult.BTWPercentage);
        }
        #endregion
        #region -------[Integration Test for index action]-------
        [TestMethod]
        public void IntegrationWinkelmandControllerReturnsWinkelmandViewModel()
        {
            //Arrange
            WinkelmandController controller = new WinkelmandController();

            try
            {
                //Act
                var result = controller.Index() as ViewResult;

                //Arrange
                Assert.IsInstanceOfType(result.Model, typeof(WinkelmandViewModel));
            }
            catch (Exception) //WCF EXCEPTION!!!!!
            {
                Assert.Fail("Kan geen verbinding maken met de service.");
            }
        }
        #endregion
    }
}
