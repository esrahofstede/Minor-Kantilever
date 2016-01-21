using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Case3.BSBestellingenbeheer.Entities;
using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using System.Transactions;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Case3.BSBestellingenbeheer.DAL.Exceptions;

namespace Case3.BSBestellingenbeheer.DAL.Tests
{
    /// <summary>
    /// Responsable for testing the BestellingDataMapper class
    /// </summary>
    [TestClass]
    public class BestellingDataMapperTest
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext testcontext)
        {
            Database.SetInitializer(new BestellingDBInitializer());
            using (var context = new BestellingContext())
            {
                context.Database.Initialize(false);
            }
        }

        #region dummydata
        private Bestelling _bestelling = new Bestelling()
        {
            ID = 334453,
            BestelDatum = new DateTime(2015, 12, 12),
            Status = 1,

            KlantNaam = "Remco",
            AdresRegel1 = "Hofmeesterij 89",
            Woonplaats = "Huissen",
            Postcode = "6852NC",
            Telefoonnummer = "0612697691",
            Artikelen = new List<Artikel>()
            {
                new Artikel()
                {
                    ID = 1,
                    Naam = "Fietsbel",
                    Leverancier = "Gazelle",
                    Leverancierscode = "GAZ01",
                    Aantal = 5
                }
            }
        };

        private Bestelling _bestellingNoKlantGegevens = new Bestelling()
        {
            ID = 1,
            BestelDatum = new DateTime(2015, 12, 12),
            Status = 1,

            Artikelen = new List<Artikel>()
            {
                new Artikel()
                {
                    ID = 1,
                    Naam = "Fietsbel",
                    Leverancier = "Gazelle",
                    Leverancierscode = "GAZ01",
                    Aantal = 5
                }
            }
        };
        #endregion

        /// <summary>
        /// GetBestellingToPack should return 1 Bestelling where the status == 0 and ordered by BestelDatum
        /// </summary>
        [TestMethod]
        public void TestGetBestellingFirstResult()
        {
            BestellingDataMapper mapper = new BestellingDataMapper();

            Bestelling result = mapper.GetBestellingToPack();

            Assert.AreEqual(1, result.ID);
            Assert.IsNotNull(result.Artikelen);
            Assert.AreEqual(4, result.Artikelen.Count);
            Assert.AreEqual("fietsbel", result.Artikelen[0].Naam);
            Assert.AreEqual("gazelle", result.Artikelen[0].Leverancier);
            Assert.AreEqual("03g54hbronlsfads", result.Artikelen[0].Leverancierscode);
            Assert.AreEqual(3, result.Artikelen[0].Aantal);
        }

        /// <summary>
        /// When a Bestelling does not exsist with the given id it should return a NullReferenceException with the message "Bestelling niet gevonden"
        /// </summary>
        [TestMethod]
        
        public void FindBestellingByIdIsThree()
        {
            //Arrange
            BestellingDataMapper mapper = new BestellingDataMapper();

            //Act
            try
            {
                Bestelling result = mapper.FindBestellingByID(1865);
                Assert.Fail("De bestelling is gevonden, terwijl dit niet zou moeten");
            }
            catch (FunctionalException ex)
            {
                //Assert
                Assert.AreEqual("Bestelling niet gevonden", ex.Message);
               Assert.AreEqual(typeof(FunctionalException), ex.GetType());
            }
        }

        /// <summary>
        /// GetBestellingToPack should return 1 Bestelling where the status == 0 and ordered by BestelDatum
        /// </summary>
        [TestMethod]
        public void FindBestellingByIdIsOne()
        {
            //Arrange
            BestellingDataMapper mapper = new BestellingDataMapper();

            //Act
            Bestelling result = mapper.FindBestellingByID(1);

            //Assert
            Assert.AreEqual(1, result.ID);
            Assert.AreEqual(0, result.Status);
        }

        /// <summary>
        /// Check if the status is 0 before calling the method and 1 after calling it. We already tested the FindBestellingByID method so we can assume it works correct here 
        /// </summary>
        [TestMethod]
        public void TestUpdateStatusOnBestelling()
        {
            //Arrange
            BestellingDataMapper mapper = new BestellingDataMapper();

            //Act
            using (TransactionScope scope = new TransactionScope())
            {
                Bestelling before = mapper.FindBestellingByID(1);

                mapper.UpdateBestellingStatusToPacked(1);

                Bestelling after = mapper.FindBestellingByID(1);

                //Assert
                Assert.AreEqual(0, before.Status);
                Assert.AreEqual(1, after.Status);
            }
        }

        [TestMethod]
        public void TestInsertBestelling()
        {
            //Arrange
            BestellingDataMapper mapper = new BestellingDataMapper();

            //Act
            using (TransactionScope scope = new TransactionScope())
            {
                mapper.Insert(_bestelling);
                Bestelling newBestelling = mapper.FindBestellingByID(_bestelling.ID);

                //Assert
                Assert.AreEqual(newBestelling.ID, _bestelling.ID);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FunctionalException))]
        public void ValidateInsertBestellingThrowsExceptionWhenBestellingIsNotValid()
        {
            //Arrange
            BestellingDataMapper mapper = new BestellingDataMapper();

            //Act
            using (TransactionScope scope = new TransactionScope())
            {
                mapper.Insert(_bestellingNoKlantGegevens);

            //Assert
            //Expect FunctionalException
            }
        }
    }
}
