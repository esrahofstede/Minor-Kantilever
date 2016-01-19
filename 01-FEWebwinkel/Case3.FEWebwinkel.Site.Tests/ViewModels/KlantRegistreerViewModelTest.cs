using Case3.FEWebwinkel.Site.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Case3.FEWebwinkel.Site.Tests.ViewModels
{
    /// <summary>
    /// Responsible for testing the KlantRegistreerViewModel Class
    /// </summary>
    [TestClass]
    public class KlantRegistreerViewModelTest
    {

        [TestMethod]
        public void CheckAllFields()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Tussenvoegsel = "van het",
                Achternaam = "Hek",
                Telefoonnummer = "0612345678",
                AdresRegel1 = "Haagstraat 5",
                AdresRegel2 = "t.a.v. afdeling inkoop",
                Postcode = "4921XA",
                Emailadres = "bob@jansen.nl",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
            Assert.AreEqual("Bob", model.Voornaam);
            Assert.AreEqual("van het", model.Tussenvoegsel);
            Assert.AreEqual("Hek", model.Achternaam);
            Assert.AreEqual("0612345678", model.Telefoonnummer);
            Assert.AreEqual("Haagstraat 5", model.AdresRegel1);
            Assert.AreEqual("t.a.v. afdeling inkoop", model.AdresRegel2);
            Assert.AreEqual("4921XA", model.Postcode);
            Assert.AreEqual("bob@jansen.nl", model.Emailadres);
            Assert.AreEqual("Made", model.Woonplaats);
        }
        #region -------[Tests for Required fields]-------
        [TestMethod]
        public void CheckRequiredFieldsKlantRegistreerViewModel()
        {
            // Arrange
            var results = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel();

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), results, true);

            // Assert
            Assert.AreEqual(6, results.Count);
            Assert.AreEqual("Voornaam is verplicht", results[0].ErrorMessage);
            Assert.AreEqual("Achternaam is verplicht", results[1].ErrorMessage);
            Assert.AreEqual("AdresRegel1 is verplicht", results[2].ErrorMessage);
            Assert.AreEqual("Postcode is verplicht", results[3].ErrorMessage);
            Assert.AreEqual("Woonplaats is verplicht", results[4].ErrorMessage);
            Assert.AreEqual("Telefoonnummer is verplicht", results[5].ErrorMessage);
        }
        #endregion
        #region -------[Tests for Voornaam]-------
        [TestMethod]
        public void VoornaamMetJuistAantalLetters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0612345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateVoornaamMetEenLetter()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "B",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("De Voornaam moet minimaal 2 letters bevatten", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateVoornaamMetMeerDan50Letters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Prince-Fritz-Cruene-August-Willem-Jan-Hendrik-Dick-Ferdinand-Prince-Fritz-Cruene-August-Willem-Jan-Hendrik-Dick-Ferdinand",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("De Voornaam mag maximaal 100 letters bevatten", resultsModel[0].ErrorMessage);

        }
        #endregion
        #region -------[Tussenvoegsel]-------
        [TestMethod]
        public void TussenvoegselMetJuistAantalLetters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Tussenvoegsel = "Van der",
                Achternaam = "Put",
                Telefoonnummer = "0612345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateTussenvoegselMetMeerDan20Letters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Tussenvoegsel = "Van-Der-Van-Der",
                Achternaam = "Put",
                Telefoonnummer = "0612345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het Tussenvoegsel mag maximaal 10 letters bevatten", resultsModel[0].ErrorMessage);
        }
        #endregion
        #region -------[Achternaam]-------
        [TestMethod]
        public void AchternaamMetJuistAantalLetters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0612345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateAchternaamMetEenLetter()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "J"
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("De Achternaam moet minimaal 2 letters bevatten", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateAchternaamMetMeerDan100Letters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "van den Heuvel tot Beichlingen, gezegd Bartolotti Rijnders de Vos van Steenwijk genaamd van Essen tot Windesheim genaamd van Thomassen à Thuessink van der Hoop van Slochteren gezegd Bartolotti Rijnders de Vos van Steenwijk genaamd van Essen tot Windesheim genaamd van Thomassen à Thuessink van der Hoop van Slochteren",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("De Achternaam mag maximaal 150 letters bevatten", resultsModel[0].ErrorMessage);
        }
        #endregion
        #region -------[Telefoonnummer]-------
        [TestMethod]
        public void JuistTelefoonNummer()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateJuistMobielNummerMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "06-12345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateTeLangMobielNummerMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "06-123456789",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateJuistNetNummerMetDrieCijfersMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "033-1234567",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateTeLangNetNummerNetNummerMetDrieCijfersMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "033-12345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateJuistNetNummerMetVierCijfersMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0162-123456",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }
        [TestMethod]
        public void ValidateJuistTelefoonnummerMetLandcode()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "+31627232007",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }
        [TestMethod]
        public void ValidateJuistTelefoonnummerMetLandcodeMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "+31-627232007",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }
        [TestMethod]
        public void ValidateTeLangNetNummerNetNummerMetVierCijfersMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0162-1234567",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateNetNummerMetVijfCijfers()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "01620-12345",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidateNetNummerMetTweeStreepjes()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "033-060-0000",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789", resultsModel[0].ErrorMessage);
        }
        [TestMethod]
        public void ValidateTelefoonnummerMetVreemdeTekens()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "06~12345678",
                AdresRegel1 = "Haagstraat 5",
                Postcode = "4921XA",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789", resultsModel[0].ErrorMessage);
        }
        #endregion
        #region -------[Postcode]-------
        [TestMethod]
        public void JuistePostcode()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void JuistePostcodeMetSpatie()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921 XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidatePostcodeBegintMet0()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "0123JM",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een postcode is: 1234AB of 1234 AB", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidatePostcodeMetVijfCijfers()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "12345JM",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een postcode is: 1234AB of 1234 AB", resultsModel[0].ErrorMessage);
        }

        [TestMethod]
        public void ValidatePostcodeMetDrieLetters()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "1234 JMK",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een postcode is: 1234AB of 1234 AB", resultsModel[0].ErrorMessage);
        }
        #endregion
        #region -------[E-mailadres]-------
        [TestMethod]
        public void JuistEmailadres()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bob@jansen.nl",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }
        [TestMethod]
        public void ValidateEmailAdresMetUnderscore()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bob_jansen@jansen.nl",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateEmailAdresMetStreepje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bob-jansen@jansen.nl",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateEmailAdresMetPunt()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bob.jansen@jansen.nl",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateEmailAdresMetSterretje()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bob*jansen@jansen.nl",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een e-mailadres is: janjansen@test.nl, jan_jansen@test.nl, jan.jansen@test.nl, jan-jansen@test.nl, janjansen@test.com", resultsModel[0].ErrorMessage);
        }
        [TestMethod]
        public void ValidateEmailAdresMetDrieLetterLandcode()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bobjansen@jansen.com",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual(0, resultsModel.Count);
        }

        [TestMethod]
        public void ValidateEmailAdresMetVierLetterLandcode()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bobjansen@jansen.enge",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een e-mailadres is: janjansen@test.nl, jan_jansen@test.nl, jan.jansen@test.nl, jan-jansen@test.nl, janjansen@test.com", resultsModel[0].ErrorMessage);
        }
        [TestMethod]
        public void ValidateEmailAdresMetEenLetterLandcode()
        {
            // Arrange
            var resultsModel = new List<ValidationResult>();
            var model = new KlantRegistreerViewModel
            {
                Voornaam = "Bob",
                Achternaam = "Jansen",
                Telefoonnummer = "0123456789",
                Postcode = "4921XA",
                AdresRegel1 = "Haagstraat 5",
                Woonplaats = "Made",
                Emailadres = "bobjansen@jansen.e",
            };

            // Act
            Validator.TryValidateObject(model, new ValidationContext(model), resultsModel, true);

            // Assert
            Assert.AreEqual("Het formaat van een e-mailadres is: janjansen@test.nl, jan_jansen@test.nl, jan.jansen@test.nl, jan-jansen@test.nl, janjansen@test.com", resultsModel[0].ErrorMessage);
        }
        #endregion
    }
}
