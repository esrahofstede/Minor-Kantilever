using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using Case3.PcSWinkelen.DAL.Contexts;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.PcSWinkelen.DAL.Tests
{
    /// <summary>
    /// TestClass for testint the WinkelMandItemDataMapper class and its functionalities
    /// </summary>
    [TestClass]
    public class WinkelmandItemDataMapperTest
    {

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Database.SetInitializer(new WinkelmandDBInitializer());
            using (var context = new WinkelmandContext())
            {
                context.Database.Initialize(false);
            }
        }

        [TestMethod]
        public void AddWinkelmandItemToDatabaseTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Arrange
                var target = new WinkelmandDataMapper();

                // Act
                target.Insert(DummyData.GetDummyWinkelmandItem);
                IEnumerable<WinkelmandItem> result = target.FindAll();

                // Assert
                Assert.AreEqual(3, result.Count());
            }
        }

        [TestMethod]
        public void GetAllWinkelmandItemsFromDatabaseTest()
        {
            // Arrange
            var target = new WinkelmandDataMapper();

            // Act
            IEnumerable<WinkelmandItem> result = target.FindAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetAllWinkelmandItemsBySessieFromDatabaseTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Arrange
                var target = new WinkelmandDataMapper();

                // Act
                target.Insert(DummyData.GetDummyWinkelmandItem);
                IEnumerable<WinkelmandItem> result = target.FindAllBy(w => w.SessieID == DummyData.GetDummyWinkelmandItem.SessieID);

                // Assert
                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public void UpdateAantalFromWinkelmandItem()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Arrange
                var target = new WinkelmandDataMapper();
                target.Insert(DummyData.GetDummyWinkelmandItem);
                var newItem = DummyData.GetDummyWinkelmandItem;
                newItem.Aantal++;
                

                // Act
                target.Update(newItem);
                List<WinkelmandItem> result = target.FindAllBy(w => w.SessieID == newItem.SessieID && w.ProductID == newItem.ProductID).ToList();

                // Assert
                Assert.AreEqual(6, result[0].Aantal);
            }
        }

        [TestMethod]
        public void FindBySessieIDNotFoundWinkelmandItem()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Arrange
                var target = new WinkelmandDataMapper();

                // Act
                var result = target.FindBySessieID("");

                // Assert
                Assert.IsInstanceOfType(result, typeof(List<WinkelmandItem>));
                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public void FindBySessieIDFoundWinkelmandItem()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Arrange
                var target = new WinkelmandDataMapper();

                // Act
                var result = target.FindBySessieID("210c796d-09a6-4ba0-a7d7-09226575f864");

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(List<WinkelmandItem>));
                Assert.AreEqual("210c796d-09a6-4ba0-a7d7-09226575f864", result[0].SessieID);
                Assert.AreEqual(1234, result[0].ProductID);
                Assert.AreEqual("58585", result[0].LeveranciersProductId);
                Assert.AreEqual("Gazelle", result[0].LeverancierNaam);
                Assert.AreEqual("Fietsbel", result[0].Naam);
                Assert.AreEqual(2.00M, result[0].Prijs);
            }
        }

        [TestMethod]
        public void DeleteFoundWinkelmandItem()
        {
            // Arrange
            string sessieID = "210c796d-09a6-4ba0-a7d7-09226575f864";
            var target = new WinkelmandDataMapper();

            using (var scope = new TransactionScope())
            {
                // Act
                List<WinkelmandItem> resultOld = target.FindBySessieID(sessieID);
                Assert.IsNotNull(resultOld);

                target.DeleteBySessieID(sessieID);
                List<WinkelmandItem> result = target.FindBySessieID(sessieID);

                // Assert
                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public void DeleteTwoFoundWinkelmandItems()
        {
            // Arrange
            string sessieID = "210c796d-09a6-4ba0-a7d7-09226575f864";
            var target = new WinkelmandDataMapper();

            using (var scope = new TransactionScope())
            {

                WinkelmandItem item2 = new WinkelmandItem
                {
                    Aantal = 5,
                    SessieID = sessieID,
                    ProductID = 1234,
                    LeveranciersProductId = "876554",
                    LeverancierNaam = "Gazelle",
                    Naam = "Fietsbel 1",
                    Prijs = 2.00M
                };
                target.Insert(item2);


                // Act
                List<WinkelmandItem> resultOld = target.FindBySessieID(sessieID);
                Assert.IsNotNull(resultOld);
                Assert.AreEqual(2, resultOld.Count);

                target.DeleteBySessieID(sessieID);
                List<WinkelmandItem> result = target.FindBySessieID(sessieID);

                // Assert
                Assert.AreEqual(0, result.Count);
            }
        }
    }
}
