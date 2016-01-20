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
                        Aantal = 1,
                        Prijs = 4.95M,
                        
                    },
                    new ArtikelViewModel
                    {
                        ArtikelNaam = "Zadelpen",
                        Leveranciersnaam = "Giant",
                        Leverancierscode = "GI12345ZP",
                        Aantal = 2,
                        Prijs = 4.95M,
                    }
                },
                BestellingID = 1,
                KlantNaam = "Bob Jansma",
                Adresregel1 = "Kerkstraat 5",
                Adresregel2 = "t.a.v. Dhr. Jansma",
                Postcode = "1234AB",
                Woonplaats = "Veenendaal",
                FactuurNummer = 10001,
                FactuurDatum = DateTime.Now,
                BTWPercentage = 21M,
                TotaalBTW = 2.58M,
                TotaalExclBTW = 12.27M,
                TotaalInclBTW = 14.85M,                
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
            Assert.AreEqual(4.95M, bestellingViewModel.Artikelen[1].Prijs);
            //Payment information
            Assert.AreEqual(21M, bestellingViewModel.BTWPercentage);
            Assert.AreEqual(2.58M, bestellingViewModel.TotaalBTW);
            Assert.AreEqual(12.27M, bestellingViewModel.TotaalExclBTW);
            Assert.AreEqual(14.85M, bestellingViewModel.TotaalInclBTW);
            //Receipt information
            Assert.AreEqual(1, bestellingViewModel.BestellingID);
            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yy"), bestellingViewModel.FactuurDatum.ToString("dd/MM/yy"));
            Assert.AreEqual(10001, bestellingViewModel.FactuurNummer);
            //Label information
            Assert.AreEqual("Bob Jansma", bestellingViewModel.KlantNaam);
            Assert.AreEqual("Kerkstraat 5", bestellingViewModel.Adresregel1);
            Assert.AreEqual("t.a.v. Dhr. Jansma", bestellingViewModel.Adresregel2);
            Assert.AreEqual("1234AB", bestellingViewModel.Postcode);
            Assert.AreEqual("Veenendaal", bestellingViewModel.Woonplaats);
        }
        #endregion
        #region -------[Tests for ChangeStatus Action]-------

        [TestMethod]
        public void ChangeStatusActionCallsManagerOneTime()
        {
            // Arrange
            Mock<IBestellingManager> mock = new Mock<IBestellingManager>(MockBehavior.Strict);
            mock.Setup(m => m.ChangeStatusOfBestelling(1));

            var controller = new BestellingController(mock.Object);

            // Act
            controller.ChangeStatus(1);
            // Assert
            mock.Verify(m => m.ChangeStatusOfBestelling(1), Times.Once);

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
