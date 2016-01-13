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
    [TestClass]
    public class WinkelmandItemDataMapperTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testcontext)
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
        public void GetOnderhoudsOpdrachtFromDatabaseTest()
        {
            // Arrange
            var target = new WinkelmandDataMapper();

            // Act
            IEnumerable<WinkelmandItem> result = target.FindAll();

            // Assert
            Assert.AreEqual(2, result.Count());
        }
    }
}
