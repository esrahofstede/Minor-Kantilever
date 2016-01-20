using System;
using System.Collections.Generic;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.PcSBestellen.Implementation.Tests
{
    [TestClass]
    public class PcSBestellenServiceHandlerTest
    {
        [TestMethod]
        public void BestellingPlaatsen()
        {
            //Arrange
            var managerMock = new Mock<IBSBestellingenManager>();
            var agentMock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.InsertBestelling(It.IsAny<InsertBestellingRequestMessage>())).Returns(new InsertBestellingResultMessage());
            var handler = new PcSBestellenServiceHandler(managerMock.Object, agentMock.Object);

            //Act
            handler.BestellingPlaatsen(DummyData.GetDummyBestellingPlaatsenRequestMessage);

            //Assert
            agentMock.Verify(agent => agent.InsertBestelling(It.IsAny<InsertBestellingRequestMessage>()), Times.Once);
        }
    }
}
