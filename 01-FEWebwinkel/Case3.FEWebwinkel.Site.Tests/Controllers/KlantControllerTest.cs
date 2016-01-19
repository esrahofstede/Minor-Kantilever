using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Site.Controllers;
using System.Web.Mvc;
using Case3.FEWebwinkel.Site.ViewModels;

namespace Case3.FEWebwinkel.Site.Tests.Controllers
{
    /// <summary>
    /// Responsible for testing the KlantController Class
    /// </summary>
    [TestClass]
    public class KlantControllerTest
    {
        [TestMethod]
        public void IndexActionReturnsViewResult()
        {
            // Arrange
            var controller = new KlantController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateActionHasCorrectModel()
        {
            // Arrange
            var controller = new KlantController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(KlantRegistreerViewModel));
        }
        [TestMethod]
        public void CreatePostReturnsModelWithErrorsTelefoonnummerMissing()
        {
            // Arrange
            var controller = new KlantController();
            controller.ModelState.AddModelError("Telefoonnummer", "Telefoonnummer is verplicht");

            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            var result = controller.Create(model) as ViewResult;

            // Assert
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
            Assert.AreEqual("Bob", (result.Model as KlantRegistreerViewModel).Voornaam);
            Assert.AreEqual("Haagstraat 5", (result.Model as KlantRegistreerViewModel).AdresRegel1);
            Assert.AreEqual("4921XA", (result.Model as KlantRegistreerViewModel).Postcode);
            Assert.AreEqual("Made", (result.Model as KlantRegistreerViewModel).Woonplaats);
        }
    }
}
