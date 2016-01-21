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
        [TestMethod]
        public void CalculatePriceInclusiveBTWAcceptsNullableDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            decimal? dec = 100.00M;
            // Act
            var result = target.CalculatePriceInclusiveBTW(dec);
            // Assert
            Assert.AreEqual(121.00M, result);
        }
        [TestMethod]
        public void CalculatePriceInclusiveBTWWithNullableDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            decimal? dec = null;
            // Act
            var result = target.CalculatePriceInclusiveBTW(dec);
            // Assert
            Assert.AreEqual(0.00M, result);
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
        [TestMethod]
        public void CalculateBTWOfPriceAcceptsNullableDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            decimal? dec = 100.00M;
            // Act
            var result = target.CalculateBTWOfPrice(dec);
            // Assert
            Assert.AreEqual(21M, result);
        }
        [TestMethod]
        public void CalculateBTWOfPriceNullableDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            decimal? dec = null;
            // Act
            var result = target.CalculateBTWOfPrice(dec);
            // Assert
            Assert.AreEqual(0M, result);
        }
        #endregion
        #region -------[Tests for CalculatePriceExclBTW]-------
        [TestMethod]
        public void CalculatePriceExclBTWIsDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculatePriceExclBTW(100.00M);
            // Assert
            Assert.IsInstanceOfType(result, typeof(decimal));
        }
        [TestMethod]
        public void CalculatePriceExclBTW121()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculatePriceExclBTW(121.00M);
            // Assert
            Assert.AreEqual(100.00M, result);
        }
        [TestMethod]
        public void CalculatePriceExclBTWOfRealPrice()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            // Act
            var result = target.CalculatePriceExclBTW(5.99M);
            // Assert
            Assert.AreEqual(4.95M, result);
        }
        [TestMethod]
        public void CalculatePriceExclBTWAcceptsNullableDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            decimal? dec = 121.00M;
            // Act
            var result = target.CalculatePriceExclBTW(dec);
            // Assert
            Assert.AreEqual(100.00M, result);
        }
        [TestMethod]
        public void CalculatePriceExclBTWNullableDecimal()
        {
            // Arrange
            //Setting up a mock of BTWConfigReader
            var mock = new Mock<BTWConfigReader>(MockBehavior.Strict);
            mock.Setup(b => b.GetBTWPercentage()).Returns(21M);

            var target = new BTWCalculator(mock.Object);
            decimal? dec = null;
            // Act
            var result = target.CalculatePriceExclBTW(dec);
            // Assert
            Assert.AreEqual(0M, result);
        }
        #endregion
        #region -------[Tests for CustomPercentage Constructor]-------
        [TestMethod]
        public void CustomPercentageHasBeenSetCorrectly()
        {
            // Arrange
            var target = new BTWCalculator(25);

            // Act
            var result = target.BTWPercentage;

            // Assert
            Assert.AreEqual(25M, result);
        }
        [TestMethod]
        public void CustomPercentageCalculatesInclCorrectly()
        {
            // Arrange
            var target = new BTWCalculator(25);

            // Act
            var result = target.CalculatePriceInclusiveBTW(100.00M);

            // Assert
            Assert.AreEqual(125.00M, result);
        }
        [TestMethod]
        public void CustomPercentageCalculatesExclCorrectly()
        {
            // Arrange
            var target = new BTWCalculator(25);

            // Act
            var result = target.CalculatePriceExclBTW(125.00M);

            // Assert
            Assert.AreEqual(100.00M, result);
        }
        [TestMethod]
        public void CustomPercentageCalculatesBTWOfPriceCorrectly()
        {
            // Arrange
            var target = new BTWCalculator(25);

            // Act
            var result = target.CalculateBTWOfPrice(100.00M);

            // Assert
            Assert.AreEqual(25.00M, result);
        }
        #endregion
    }
}
