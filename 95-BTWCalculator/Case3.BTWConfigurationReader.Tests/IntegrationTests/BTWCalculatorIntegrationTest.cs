using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.BTWConfigurationReader.Tests.IntegrationTests
{
    /// <summary>
    /// Responsible for Integration testing the BTWCalculator Class
    /// </summary>
    [TestClass]
    public class BTWCalculatorIntegrationTest
    {
        #region -------[IntegrationTests for GetBTWPercentage]-------
        [TestMethod]
        public void BTWCalculatorIntegrationTestGetPercentage()
        {
            // Arrange
            var target = new BTWCalculator();

            // Act
            var result = target.BTWPercentage;

            // Assert
            Assert.AreEqual(21M, result);
        }
        #endregion
        #region -------[IntegrationTests for CalculateBTWOfPrice]-------
        [TestMethod]
        public void BTWCalculatorIntegrationTestCalculateBTWOfPrice()
        {
            // Arrange
            var target = new BTWCalculator();

            // Act
            var result = target.CalculateBTWOfPrice(100.00M);

            // Assert
            Assert.AreEqual(21M, result);
        }
        [TestMethod]
        public void BTWCalculatorIntegrationTestCalculateBTWOfPriceNullable()
        {
            // Arrange
            var target = new BTWCalculator();
            decimal? dec = 100.00M;
            // Act
            var result = target.CalculateBTWOfPrice(dec);

            // Assert
            Assert.AreEqual(21M, result);
        }
        [TestMethod]
        public void BTWCalculatorIntegrationTestCalculateBTWOfPriceNull()
        {
            // Arrange
            var target = new BTWCalculator();
            decimal? dec = null;
            // Act
            var result = target.CalculateBTWOfPrice(dec);

            // Assert
            Assert.AreEqual(0M, result);
        }
        #endregion
        #region -------[IntegrationTests for CalculatePriceInclBTW]-------
        [TestMethod]
        public void BTWCalculatorIntegrationTestCalculatePriceInclBTW()
        {
            // Arrange
            var target = new BTWCalculator();

            // Act
            var result = target.CalculatePriceInclusiveBTW(100.00M);

            // Assert
            Assert.AreEqual(121.00M, result);
        }
        [TestMethod]
        public void BTWCalculatorIntegrationTestCalculatePriceInclBTWNullable()
        {
            // Arrange
            var target = new BTWCalculator();
            decimal? dec = 100.00M;
            // Act
            var result = target.CalculatePriceInclusiveBTW(dec);

            // Assert
            Assert.AreEqual(121.00M, result);
        }
        [TestMethod]
        public void BTWCalculatorIntegrationTestCalculatePriceInclBTWNull()
        {
            // Arrange
            var target = new BTWCalculator();
            decimal? dec = null;
            // Act
            var result = target.CalculatePriceInclusiveBTW(dec);

            // Assert
            Assert.AreEqual(0M, result);
        }
        #endregion
    }
}
