using System;
using System.Configuration;
using System.Globalization;

namespace Case3.BTWConfigurationReader
{
    /// <summary>
    /// Responsible for reading out the configuration file
    /// </summary>
    public class BTWConfigReader
    {
        /// <summary>
        /// This function returns the BTW percentage that is needed for calculation purposes
        /// </summary>
        /// <returns>Returns the BTW percentage</returns>
        public virtual decimal GetBTWPercentage()
        {
            BTWPercentageSection config = ConfigurationManager.GetSection("paymentData/btwPercentages") as BTWPercentageSection;
            return Convert.ToDecimal(config.BTWPercentage.Percentage, CultureInfo.InvariantCulture);
        }
    }
}
