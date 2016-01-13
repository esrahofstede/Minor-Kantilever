using System.Collections.Generic;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Case3.FEWebwinkel.Site.Controllers;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Moq;

namespace Case3.FEWebwinkel.Site.Tests.Controllers
{
    /// <summary>
    /// Responsible for testing the CatalogusController Class
    /// </summary>
    [TestClass]
    public class CatalogusControllerTest
    {
        #region -------[Support functions for tests]-------
        private List<CatalogusViewModel> CreateCatalogusViewModelList()
        {
            return new List<CatalogusViewModel>
            {
                new CatalogusViewModel
                {
                    ID = 1,
                    Naam = "Fietsbel",
                    Prijs = 4.95M,
                    Afbeeldingslocatie = "../Content/Product_img/fietsbel.gif",
                    Leverancier = "Gazelle",
                    Voorraad = 10,
                },
                new CatalogusViewModel
                {
                    ID = 2,
                    Naam = "Spaak",
                    Prijs = 0.75M,
                    Afbeeldingslocatie = "../Content/Product_img/spaak.gif",
                    Leverancier = "Giant",
                    Voorraad = 30,
                }
            };
        }
        #endregion
        [TestMethod]
        public void CursusControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var catalogusList = CreateCatalogusViewModelList();
            var mock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            mock.Setup(c => c.GetProducts()).Returns(catalogusList);

            var controller = new CatalogusController(mock.Object);

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void CursusControllerIndexActionHasCorrectModel()
        {
            // Arrange
            var catalogusList = CreateCatalogusViewModelList();
            var mock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            mock.Setup(c => c.GetProducts()).Returns(catalogusList);

            var controller = new CatalogusController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var modelInView = result.Model as List<CatalogusViewModel>;
            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(List<CatalogusViewModel>));
            //First Item
            Assert.AreEqual(1, modelInView[0].ID);
            Assert.AreEqual("Fietsbel", modelInView[0].Naam);
            Assert.AreEqual(4.95M, modelInView[0].Prijs);
            Assert.AreEqual("../Content/Product_img/fietsbel.gif", modelInView[0].Afbeeldingslocatie);
            Assert.AreEqual("Gazelle", modelInView[0].Leverancier);
            Assert.AreEqual(10, modelInView[0].Voorraad);
            //Second Item
            Assert.AreEqual(2, modelInView[1].ID);
            Assert.AreEqual("Spaak", modelInView[1].Naam);
            Assert.AreEqual(0.75M, modelInView[1].Prijs);
            Assert.AreEqual("../Content/Product_img/spaak.gif", modelInView[1].Afbeeldingslocatie);
            Assert.AreEqual("Giant", modelInView[1].Leverancier);
            Assert.AreEqual(30, modelInView[1].Voorraad);
        }
    }
}
