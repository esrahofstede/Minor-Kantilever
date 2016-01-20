using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.FEWebwinkel.Agent.Interfaces;
using Moq;
using Case3.FEWebwinkel.Site.Managers;
using case3bsbestellingenbeheer.v1.schema;

namespace Case3.FEWebwinkel.Site.Tests.Managers
{
    [TestClass]
    public class BestellingManagerTest
    {
        private static KlantRegistreerViewModel CreateKlant()
        {
            return new KlantRegistreerViewModel
            {
                Voornaam = "Sjaak",
                Tussenvoegsel = "de",
                Achternaam = "Vries",
                AdresRegel1 = "Bosweg 3",
                Postcode = "6802BR",
                Woonplaats = "Amsterdam",
                Telefoonnummer = "06-12900921"
            };
        }

        [TestMethod]
        public void ManagerConvertsKlantViewModelToDTO()
        {
            // Arrange
            var klant = CreateKlant();
            //needed to prevent that BestellingManager connects to PcSWinkelen
            var target = new BestellingManager();

            // Act
            var result = target.ConvertKlantViewModelToDTO(klant);

            // Assert
            Assert.AreEqual(typeof(Klantgegevens), result.GetType());
        }

        [TestMethod]
        public void ManagerConvertsKlantViewModelToDTOWithCorrectData()
        {
            // Arrange
            var klant = CreateKlant();
            var target = new BestellingManager();

            // Act
            var result = target.ConvertKlantViewModelToDTO(klant);

            // Assert
            Assert.AreEqual("Sjaak de Vries",result.Naam);
            Assert.AreEqual("Bosweg 3", result.Adresregel1);
            Assert.AreEqual(null, result.Adresregel2);
            Assert.AreEqual("6802BR", result.Postcode);
            Assert.AreEqual("Amsterdam", result.Woonplaats);
            Assert.AreEqual("06-12900921", result.Telefoonnummer);
        }

        [TestMethod]
        public void ManagerCallsAgentToPlaceBestelling()
        {
            // Arrange
            var klant = CreateKlant();
            //needed to prevent that BestellingManager connects to PcSWinkelen
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(x => x.SendBestelling("test", It.IsAny<Klantgegevens>()));
            var target = new BestellingManager(agentMock.Object);

            // Act
            target.PlaatsBestelling("test", klant);

            // Assert
            agentMock.Verify(x => x.SendBestelling("test", It.IsAny<Klantgegevens>()), Times.Once());
        }
    }
}
