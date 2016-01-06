using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.BTWConfigurationReader.Tests
{
    /// <summary>
    /// Responsible for testing the BTWCalculator Class
    /// </summary>
    [TestClass]
    public class BTWCalculatorTest
    {
        #region -------[Tests for GetBTWPercentage]-------
        [TestMethod]
        public void GetBTWPercentageIsDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.BTWPercentage;
            // Assert
            Assert.IsInstanceOfType(result, typeof(decimal));
        }
        [TestMethod]
        public void GetBTWPercentage()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.BTWPercentage;
            // Assert
            Assert.AreEqual(21M, result);
        }
        #endregion
        #region -------[Tests for CalculatePriceInclBTW]-------
        [TestMethod]
        public void CalculatePriceInclusiveBTWIsDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculatePriceInclusiveBTW(100.00M);
            // Assert
            Assert.IsInstanceOfType(result, typeof(decimal));
        }
        [TestMethod]
        public void CalculatePrice100InclusiveBTW()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculatePriceInclusiveBTW(100.00M);
            // Assert
            Assert.AreEqual(121.00M, result);
        }
        [TestMethod]
        public void CalculateRealPriceInclusiveBTW()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculatePriceInclusiveBTW(4.09M);
            // Assert
            Assert.AreEqual(4.95M, result);
        }
        #endregion
        #region -------[Tests for CalculateBTWOfPrice]-------
        [TestMethod]
        public void CalculateBTWOfPriceIsDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculateBTWOfPrice(100M);
            // Assert
            Assert.IsInstanceOfType(result, typeof(decimal));
        }
        [TestMethod]
        public void CalculateBTWOfPrice100()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculateBTWOfPrice(100M);
            // Assert
            Assert.AreEqual(21M, result);
        }
        [TestMethod]
        public void CalculateBTWOfRealPrice()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculateBTWOfPrice(4.95M);
            // Assert
            Assert.AreEqual(1.04M, result);
        }
        #endregion
    }
}
