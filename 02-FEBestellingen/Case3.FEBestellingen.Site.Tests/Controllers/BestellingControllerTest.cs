using Case3.FEBestellingen.Site.Controllers;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Tests.Controllers
{
    /// <summary>
    /// Responsible for testing the BestellingController Class
    /// </summary>
    [TestClass]
    public class BestellingControllerTest
    {
        #region -------[Support functions for tests]-------
        private BestellingViewModel CreateBestellingViewModel()
        {
            return new BestellingViewModel
            {
                Artikelen = new List<ArtikelViewModel>
                {
                    new ArtikelViewModel
                    {
                        ArtikelNaam = "Fietsbel",
                        Leveranciersnaam = "Gazelle",
                        Leverancierscode = "GA12345FB",
                        Aantal = 1
                    },
                    new ArtikelViewModel
                    {
                        ArtikelNaam = "Zadelpen",
                        Leveranciersnaam = "Giant",
                        Leverancierscode = "GI12345ZP",
                        Aantal = 2
                    }
                }
            };
        }
        #endregion
        #region -------[Tests for Index Action]-------
        [TestMethod]
        public void BestellingControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var mock = new Mock<IBestellingManager>(MockBehavior.Strict);
            mock.Setup(m => m.FindNextBestelling(It.IsAny<FindNextBestellingRequestMessage>()))
                .Returns(new BestellingViewModel());

            var controller = new BestellingController(mock.Object);

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void BestellingControllerIndexActionHasCorrectModel()
        {
            var model = CreateBestellingViewModel();
            // Arrange
            var mock = new Mock<IBestellingManager>(MockBehavior.Strict);
            mock.Setup(m => m.FindNextBestelling(It.IsAny<FindNextBestellingRequestMessage>()))
                .Returns(model);

            var controller = new BestellingController(mock.Object);


            // Act
            ViewResult result = controller.Index() as ViewResult;
            var bestellingViewModel = result.Model as BestellingViewModel;
            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(BestellingViewModel));

            //First item
            Assert.AreEqual("Fietsbel", bestellingViewModel.Artikelen[0].ArtikelNaam);
            Assert.AreEqual("Gazelle", bestellingViewModel.Artikelen[0].Leveranciersnaam);
            Assert.AreEqual("GA12345FB", bestellingViewModel.Artikelen[0].Leverancierscode);
            Assert.AreEqual(1, bestellingViewModel.Artikelen[0].Aantal);
            //Second item
            Assert.AreEqual("Zadelpen", bestellingViewModel.Artikelen[1].ArtikelNaam);
            Assert.AreEqual("Giant", bestellingViewModel.Artikelen[1].Leveranciersnaam);
            Assert.AreEqual("GI12345ZP", bestellingViewModel.Artikelen[1].Leverancierscode);
            Assert.AreEqual(2, bestellingViewModel.Artikelen[1].Aantal);
        }
        #endregion
        #region -------[IntegrationTests]-------

        /*[TestMethod]
        public void IntegrationBestellingController()
        {
            // Arrange
            var controller = new BestellingController();

            try
            {
                // Act
                var result = controller.Index();

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
            catch (Exception)
            {
                Assert.Fail("De service kon niet gevonden worden");
            }
        }*/
        #endregion
    }
}
