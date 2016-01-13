using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEBestellingen.Site.Controllers;
using System.Web.Mvc;
using Case3.FEBestellingen.Site.ViewModels;

namespace Case3.FEBestellingen.Site.Tests.Controllers
{
    /// <summary>
    /// Responsible for testing the BestellingController Class
    /// </summary>
    [TestClass]
    public class BestellingControllerTest
    {
        [TestMethod]
        public void BestellingControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var controller = new BestellingController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void BestellingControllerIndexActionHasCorrectModel()
        {
            // Arrange
            var controller = new BestellingController();


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(BestellingViewModel));
        }
    }
}
