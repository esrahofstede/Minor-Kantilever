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
        #endregion
        #region -------[IntegrationTests for CalculatePriceInclBTW]-------
        public void BTWCalculatorIntegrationTestCalculatePriceInclBTW()
        {
            // Arrange
            var target = new BTWCalculator();

            // Act
            var result = target.CalculatePriceInclusiveBTW(100.00M);

            // Assert
            Assert.AreEqual(121.00M, result);
        }
        #endregion
    }
}
