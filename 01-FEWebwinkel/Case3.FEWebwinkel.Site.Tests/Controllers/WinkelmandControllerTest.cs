using Case3.FEWebwinkel.Site.Controllers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Tests.Controllers
{
    [TestClass]
    public class WinkelmandControllerTest
    {
        private static List<ArtikelViewModel> CreateWinkelmandViewModel()
        {
            var viewmodels = new List<ArtikelViewModel>()
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
            };

            return viewmodels;
        }

        [TestMethod]
        public void WinkelmandControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var artikelList = CreateWinkelmandViewModel();
            var mock = new Mock<IWinkelmandManager>(MockBehavior.Strict);
            mock.Setup(wm => wm.GetWinkelmand(It.IsAny<string>())).Returns(artikelList);

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
            var artikelList = CreateWinkelmandViewModel();
            var mock = new Mock<IWinkelmandManager>(MockBehavior.Strict);
            mock.Setup(wm => wm.GetWinkelmand(It.IsAny<string>())).Returns(artikelList);

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
            Assert.AreEqual(27.10M, modelResult.TotaalInclBTW);
            //Assert.AreEqual(2.90M, modelResult.TotaalExclBTW);
            Assert.AreEqual(21, modelResult.BTWPercentage);
            //Assert.AreEqual(24.20, modelResult.TotaalBTW);
        }



    }
}
