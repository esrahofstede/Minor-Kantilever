using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Case3.BSBestellingenbeheer.Entities;

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

        [TestMethod]
        public void TestGetBestellingToPack()
        {
            BestellingDataMapper mapper = new BestellingDataMapper();

            Bestelling result = mapper.GetBestellingToPack(new BestellingContext());

            Assert.AreEqual(1, result.ID);
        }
    }
}
