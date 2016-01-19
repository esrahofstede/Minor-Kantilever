using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEBestellingen.Site.Controllers;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Tests.Controllers
{
    [TestClass]
    public class FactuurControllerTest
    {
        [TestMethod]
        public void FactuurControllerCreateInstance()
        {
            // Arrange

            // Act
            var factuurController = new FactuurController();

            // Assert
            Assert.IsNotNull(factuurController);
            Assert.IsInstanceOfType(factuurController, typeof(FactuurController));
        }

        #region -------[Tests for Index Action]-------
        [TestMethod]
        public void FactuurControllerIndexReturnTypeCheck()
        {
            // Arrange
            var factuurController = new FactuurController();

            // Act
            var result = factuurController.Index();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        #endregion


        #region -------[Tests for AfleverAdres Action]-------
        [TestMethod]
        public void FactuurControllerFactuurReturnTypeCheck()
        {
            // Arrange
            var factuurController = new FactuurController();

            // Act
            var result = factuurController.AfleverAdres();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
