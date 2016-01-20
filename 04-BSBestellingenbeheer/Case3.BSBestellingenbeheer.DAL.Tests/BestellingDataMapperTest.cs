using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Case3.BSBestellingenbeheer.Entities;
using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using System.Transactions;

namespace Case3.BSBestellingenbeheer.DAL.Tests
{
    /// <summary>
    /// Responsable for testing the BestellinDataMapper class
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
                Bestelling result = mapper.FindBestellingByID(3);
            }
            catch (NullReferenceException ex)
            {
                //Assert
                Assert.AreEqual("Bestelling niet gevonden", ex.Message);
                Assert.AreEqual(typeof(NullReferenceException), ex.GetType());
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

    }
}
