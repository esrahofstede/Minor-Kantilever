﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;
using Case3.BSCatalogusBeheer.Schema.Prod;

namespace Case3.PcSWinkelen.Agent.Tests
{
    [TestClass]
    public class BSCatalogusBeheerAgentTest
    {

        /// <summary>
        /// Create instance and then check if instance is set.
        /// </summary>
        [TestMethod]
        public void CreateInstance()
        {
            // Arrange

            // Act
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Assert
            Assert.IsNotNull(bSCatalogusBeheerAgent);
        }

        /// <summary>
        /// Retrieve products and then check of it returns a list
        /// </summary>
        [TestMethod]
        public void FindProductsReturnsList()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            var products = bSCatalogusBeheerAgent.GetProducts();

            // Assert
            Assert.IsInstanceOfType(products, typeof(List<Product>));
        }

        /// <summary>
        /// Retrieve products and then check the count of the list received is 3
        /// </summary>
        [TestMethod]
        public void FindProductsReturnsListCount3()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            IEnumerable<Product> products = bSCatalogusBeheerAgent.GetProducts();

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());
        }

        /// <summary>
        /// Retrieve product 1, then check if the product received is really product 1
        /// </summary>
        [TestMethod]
        public void FindProductsIsProduct1ReallyProduct1()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            IEnumerable<Product> products = bSCatalogusBeheerAgent.GetProducts();
            Product firstProduct = products.First();

            // Assert
            Assert.IsNotNull(firstProduct);
            Assert.AreEqual(1, firstProduct.Id);
            Assert.AreEqual("Fietsbel", firstProduct.Naam);
            Assert.AreEqual("G001", firstProduct.LeveranciersProductId);
            Assert.AreEqual("Gazelle", firstProduct.LeverancierNaam);
            Assert.AreEqual("9200000015506874.jpg", firstProduct.AfbeeldingURL);
            Assert.AreEqual("Mooie fietsbel", firstProduct.Beschrijving);
            Assert.AreEqual(DateTime.Parse("2016-02-10 10:30:00"), firstProduct.LeverbaarTot);
            Assert.AreEqual(DateTime.Parse("2016-01-06 16:00:00"), firstProduct.LeverbaarVanaf);
            Assert.AreEqual(150.00M, firstProduct.Prijs);
        }

        /// <summary>
        /// Retrieve product 2, then check if the product received is really product 2
        /// </summary>
        [TestMethod]
        public void FindProductsIsProduct2ReallyProduct2()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            IEnumerable<Product> products = bSCatalogusBeheerAgent.GetProducts();
            Product secondProduct = products.ElementAt(1);

            // Assert
            Assert.IsNotNull(secondProduct);
            Assert.AreEqual(2, secondProduct.Id);
            Assert.AreEqual("Zadel", secondProduct.Naam);
            Assert.AreEqual("B001", secondProduct.LeveranciersProductId);
            Assert.AreEqual("Batavus", secondProduct.LeverancierNaam);
            Assert.AreEqual("zadels.jpg", secondProduct.AfbeeldingURL);
            Assert.AreEqual("Mooie zadel", secondProduct.Beschrijving);
            Assert.AreEqual(DateTime.Parse("2016-02-10 10:30:00"), secondProduct.LeverbaarTot);
            Assert.AreEqual(DateTime.Parse("2016-01-06 16:00:00"), secondProduct.LeverbaarVanaf);
            Assert.AreEqual(200.00M, secondProduct.Prijs);
        }

        /// <summary>
        /// Retrieve products by page and page length. Then check the count of the list received is 3
        /// </summary>
        [TestMethod]
        public void FindProductsByPageAndLengthReturnsListCount3()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            IEnumerable<Product> products = bSCatalogusBeheerAgent.GetProducts(1, 5);

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count());
        }

        /// <summary>
        /// Retrieve products by page and page lenght. When product is received check if the product is really product 1
        /// </summary>
        [TestMethod]
        public void FindProductsByPageAndLengthProduct1ReallyProduct1()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            IEnumerable<Product> products = bSCatalogusBeheerAgent.GetProducts(1, 5);
            Product firstProduct = products.First();

            // Assert
            Assert.IsNotNull(firstProduct);
            Assert.AreEqual(1, firstProduct.Id);
            Assert.AreEqual("Fietsbel", firstProduct.Naam);
            Assert.AreEqual("G001", firstProduct.LeveranciersProductId);
            Assert.AreEqual("Gazelle", firstProduct.LeverancierNaam);
            Assert.AreEqual("9200000015506874.jpg", firstProduct.AfbeeldingURL);
            Assert.AreEqual("Mooie fietsbel", firstProduct.Beschrijving);
            Assert.AreEqual(DateTime.Parse("2016-02-10 10:30:00"), firstProduct.LeverbaarTot);
            Assert.AreEqual(DateTime.Parse("2016-01-06 16:00:00"), firstProduct.LeverbaarVanaf);
            Assert.AreEqual(150.00M, firstProduct.Prijs);
        }

        /// <summary>
        /// Retrieve products by page and page lenght. When product is received check if the product is really product 2
        /// </summary>
        [TestMethod]
        public void FindProductsByPageAndLengthProduct2ReallyProduct2()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            IEnumerable<Product> products = bSCatalogusBeheerAgent.GetProducts(1, 5);
            Product secondProduct = products.ElementAt(1);

            // Assert
            Assert.IsNotNull(secondProduct);
            Assert.AreEqual(2, secondProduct.Id);
            Assert.AreEqual("Zadel", secondProduct.Naam);
            Assert.AreEqual("B001", secondProduct.LeveranciersProductId);
            Assert.AreEqual("Batavus", secondProduct.LeverancierNaam);
            Assert.AreEqual("zadels.jpg", secondProduct.AfbeeldingURL);
            Assert.AreEqual("Mooie zadel", secondProduct.Beschrijving);
            Assert.AreEqual(DateTime.Parse("2016-02-10 10:30:00"), secondProduct.LeverbaarTot);
            Assert.AreEqual(DateTime.Parse("2016-01-06 16:00:00"), secondProduct.LeverbaarVanaf);
            Assert.AreEqual(200.00M, secondProduct.Prijs);
        }

        // Arrange

        // Act

        // Assert



    }
}
