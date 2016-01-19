using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    [TestClass]
    public class BSBestellingenServiceHandlerTest
    {
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
