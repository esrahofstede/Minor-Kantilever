using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Case3.BSBestellingenbeheer.Entities;
using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.DAL.DataMappers;

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
        public void TestGetBestellingFirstResult()
        {
            BestellingDataMapper mapper = new BestellingDataMapper();

            Bestelling result = mapper.GetBestellingToPack(new BestellingContext());

            Assert.AreEqual(1, result.ID);
            Assert.IsNotNull(result.Artikelen);
            Assert.AreEqual(4, result.Artikelen.Count);
            Assert.AreEqual("fietsbel", result.Artikelen[0].Naam);
            Assert.AreEqual("gazelle", result.Artikelen[0].Leverancier);
            Assert.AreEqual("03g54hbronlsfads", result.Artikelen[0].Leverancierscode);
            Assert.AreEqual(3, result.Artikelen[0].Aantal);
        }

    }
}
