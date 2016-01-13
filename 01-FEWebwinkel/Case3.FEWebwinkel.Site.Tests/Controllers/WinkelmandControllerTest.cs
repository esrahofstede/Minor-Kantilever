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
        [TestMethod]
        public void WinkelmandControllerIndexActionReturnsViewResult()
        {
            // Arrange
            var controller = new WinkelmandController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void WinkelmandControllerIndexActionHasCorrectModel()
        {
            // Arrange
            var controller = new WinkelmandController();


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(WinkelmandViewModel));
        }

        [TestMethod]
        public void WinkelmandControllerIndexActionHasViewsFromCookie()
        {
            // Arrange
            //ICookieNator<WinkelmandViewModel> cookieNator = 
            var controller = new WinkelmandController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result.Model, typeof(WinkelmandViewModel));
        }



    }
}
