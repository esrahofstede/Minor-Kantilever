using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    /// <summary>
    /// Testclass for testing the BSBestellingenServiceHandler class
    /// </summary>
    [TestClass]
    public class BSBestellingenServiceHandlerTest
    {
        /// <summary>
        /// Test to check if instantiating a BSBestellingenServiceHandler works correctly
        /// </summary>
        [TestMethod]
        public void BSBestellingenServiceHandlerCreateInstance()
        {
            // Arrange

            // Act
            var bSBestellingenServiceHandler = new BSBestellingenServiceHandler();

            // Assert
            Assert.IsNotNull(bSBestellingenServiceHandler);
            Assert.IsInstanceOfType(bSBestellingenServiceHandler, typeof(BSBestellingenServiceHandler));
        }
    }
}
