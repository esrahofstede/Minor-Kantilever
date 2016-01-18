using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.DAL.Context;
using System.Linq;
using Case3.BSBestellingenbeheer.Entities;
using System.Collections.Generic;

namespace Case3.BSBestellingenbeheer.DAL.Tests
{
    [TestClass]
    public class BestellingContextTest
    {
        [TestMethod]
        public void CheckBestellingContextArtikelen()
        {
            //Arrange 
            using (var context = new BestellingContext())
            {
                //Act
                var artikelen = context.Artikelen.ToList();

                //Assert
                Assert.IsInstanceOfType(artikelen, typeof(List<Artikel>));
                Assert.IsNotNull(artikelen);
                Assert.AreEqual(8, artikelen.Count);
                Assert.AreEqual(1, artikelen[0].ID);
            }
        }

        [TestMethod]
        public void CheckBestellingContextBestellingen()
        {
            //Arrange 
            using (var context = new BestellingContext())
            {
                //Act
                var bestellingen = context.Bestellingen.ToList();

                //Assert
                Assert.IsInstanceOfType(bestellingen, typeof(List<Bestelling>));
                Assert.IsNotNull(bestellingen);
                Assert.AreEqual(2, bestellingen.Count);
                Assert.AreEqual(1, bestellingen[0].ID);
            }
        }


        //Arrange 

        //Act

        //Assert

    }
}
