using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.BTWConfigurationReader.Tests
{
    /// <summary>
    /// Responsible for testing the BTWConfigReader Class
    /// </summary>
    [TestClass]
    public class BTWConfigReaderTest
    {
        [TestMethod]
        public void GetBTWPercentageFromConfig()
        {
            // Arrange
            var target = new BTWConfigReader();

            // Act
            var result = target.GetBTWPercentage();

            // Assert
            Assert.AreEqual(21M, result);
            Assert.IsInstanceOfType(result, typeof(decimal));
        }
    }
}
