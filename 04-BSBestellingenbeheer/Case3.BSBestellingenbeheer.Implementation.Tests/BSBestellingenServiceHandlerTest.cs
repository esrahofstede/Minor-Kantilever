using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.Implementation.Tests.Manager;
using Case3.BSBestellingenbeheer.V1.Messages;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    [TestClass]
    public class BSBestellingenServiceHandlerTest
    {
        [TestMethod]
        public void CreateInstance()
        {
            //Arrange

            //Act
            BSBestellingenServiceHandler bSbestellingenServiceHandler = new BSBestellingenServiceHandler();

            //Arrange
            Assert.IsNotNull(bSbestellingenServiceHandler);
            Assert.IsInstanceOfType(bSbestellingenServiceHandler, typeof(BSBestellingenServiceHandler));
        }

        [TestMethod]
        public void CreateInstanceWithMock()
        {
            //Arrange
            BestellingManagerMock bestellingManagerMock = new BestellingManagerMock();

            //Act
            BSBestellingenServiceHandler bSbestellingenServiceHandler = new BSBestellingenServiceHandler(bestellingManagerMock);

            //Arrange
            Assert.IsNotNull(bSbestellingenServiceHandler);
            Assert.IsInstanceOfType(bSbestellingenServiceHandler, typeof(BSBestellingenServiceHandler));
        }

        [TestMethod]
        public void CheckValuesFromFindFirstBestellingMethodWithMock()
        {
            //Arrange
            BestellingManagerMock bestellingManagerMock = new BestellingManagerMock();
            BSBestellingenServiceHandler bSbestellingenServiceHandler = new BSBestellingenServiceHandler(bestellingManagerMock);

            //Act
            FindFirstBestellingResultMessage findFirstBestellingResultMessage = bSbestellingenServiceHandler.FindFirstBestelling(new FindFirstBestellingRequestMessage());

            //Arrange
            Assert.IsNotNull(findFirstBestellingResultMessage);
            Assert.IsInstanceOfType(findFirstBestellingResultMessage, typeof(FindFirstBestellingResultMessage));
            
        }
    }
}
