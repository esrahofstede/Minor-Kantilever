﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Site.Controllers;
using System.Web.Mvc;
using Case3.FEWebwinkel.Site.Models;
using System.Collections.Generic;
using Case3.FEWebwinkel.Site.Managers.Interfaces;

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
