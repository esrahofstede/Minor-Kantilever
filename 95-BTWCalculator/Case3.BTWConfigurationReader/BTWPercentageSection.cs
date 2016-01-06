using System.Configuration;

namespace Case3.BTWConfigurationReader
{
    /// <summary>
    /// Responsible for specifying the BTW section in the configuration file
    /// </summary>
    public class BTWPercentageSection : ConfigurationSection
    {
        /// <summary>
        /// Responsible for the element btwPercentage in the configuration file
        /// </summary>
        [ConfigurationProperty("btwPercentage", IsRequired = true)]
        public BTWPercentageElement BTWPercentage
        {
            get { return (BTWPercentageElement)this["btwPercentage"]; }
        }
    }
    /// <summary>
    /// Responsible for the element percentage in the configuration file
    /// </summary>
    public class BTWPercentageElement : ConfigurationElement
    {
        [ConfigurationProperty("percentage", IsRequired = true)]
        public string Percentage
        {
            get { return (string)this["percentage"]; }
        }
    }
}
