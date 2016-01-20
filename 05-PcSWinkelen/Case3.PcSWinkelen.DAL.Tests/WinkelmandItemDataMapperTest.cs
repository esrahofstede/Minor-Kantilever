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

    }
}
