using System.Collections.Generic;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Case3.FEWebwinkel.Site.Controllers;
using Case3.FEWebwinkel.Site.ViewModels;


namespace Case3.FEWebwinkel.Site.Tests.Controllers
{
    /// <summary>
    /// Responsible for testing the CatalogusController Class
    /// </summary>
    [TestClass]
    public class CatalogusControllerTest
    {
        [TestMethod]
        public void CursusControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var controller = new CatalogusController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void CursusControllerIndexActionHasCorrectModel()
        {
            // Arrange
            var controller = new CatalogusController();


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(List<CatalogusViewModel>));
        }
    }
}
