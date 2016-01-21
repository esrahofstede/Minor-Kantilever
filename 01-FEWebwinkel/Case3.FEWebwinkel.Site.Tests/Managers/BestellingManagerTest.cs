using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.FEWebwinkel.Agent.Interfaces;
using Moq;
using Case3.FEWebwinkel.Site.Managers;
using Case3.PcSWinkelen.Schema;

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

        private static KlantRegistreerViewModel CreateKlantWithoutTussenvoegsel()
        {
            return new KlantRegistreerViewModel
            {
                Voornaam = "Sjaak",
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
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new BestellingManager(agentMock.Object);

            // Act
            var result = target.ConvertKlantViewModelToDTO(klant);

            // Assert
            Assert.AreEqual(typeof(KlantgegevensPcS), result.GetType());
        }

        [TestMethod]
        public void ManagerConvertsKlantViewModelToDTOWithCorrectData()
        {
            // Arrange
            var klant = CreateKlant();
            //needed to prevent that BestellingManager connects to PcSWinkelen
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new BestellingManager(agentMock.Object);

            // Act
            var result = target.ConvertKlantViewModelToDTO(klant);

            // Assert
            Assert.AreEqual("Sjaak de Vries",result.Naam);
            Assert.AreEqual("Bosweg 3", result.Adresregel1);
            Assert.AreEqual(null, result.Adresregel2);
            Assert.AreEqual("6802BR", result.Postcode);
            Assert.AreEqual("Amsterdam", result.Woonplaats);
        }

        [TestMethod]
        public void ManagerConvertsKlantViewModelWithoutTussenvoegselToDTO()
        {
            // Arrange
            var klant = CreateKlantWithoutTussenvoegsel();
            //needed to prevent that BestellingManager connects to PcSWinkelen
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new BestellingManager(agentMock.Object);

            // Act
            var result = target.ConvertKlantViewModelToDTO(klant);

            // Assert
            Assert.AreEqual("Sjaak Vries", result.Naam);
            Assert.AreEqual("Bosweg 3", result.Adresregel1);
            Assert.AreEqual(null, result.Adresregel2);
            Assert.AreEqual("6802BR", result.Postcode);
            Assert.AreEqual("Amsterdam", result.Woonplaats);
        }

        [TestMethod]
        public void ManagerCallsAgentToPlaceBestelling()
        {
            // Arrange
            var klant = CreateKlant();
            //needed to prevent that BestellingManager connects to PcSWinkelenAgent
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(x => x.SendBestelling("test", It.IsAny<KlantgegevensPcS>(), It.IsAny<int>()));
            var target = new BestellingManager(agentMock.Object);

            // Act
            target.PlaatsBestelling("test", klant);

            // Assert
            agentMock.Verify(x => x.SendBestelling("test", It.IsAny<KlantgegevensPcS>(), It.IsAny<int>()), Times.Once());
        }
    }
}
