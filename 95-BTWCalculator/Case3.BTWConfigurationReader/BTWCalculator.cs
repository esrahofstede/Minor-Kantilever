﻿using System;

namespace Case3.BTWConfigurationReader
{
    public class BTWCalculator
    {
        private BTWConfigReader _configReader;
        private decimal _btwPercentage;

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public BTWCalculator()
        {
            _configReader = new BTWConfigReader();
            _btwPercentage = _configReader.GetBTWPercentage();
        }

        /// <summary>
        /// This constructor is the constructor for a custom btw percentage
        /// </summary>
        public BTWCalculator(int percentage)
        {
            _configReader = new BTWConfigReader();
            _btwPercentage = Convert.ToDecimal(percentage);
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="configReader">This should be a mock of BTWConfigReader</param>
        public BTWCalculator(BTWConfigReader configReader)
        {
            _configReader = configReader;
            _btwPercentage = _configReader.GetBTWPercentage();
        }

        /// <summary>
        /// This property returns the BTW percentage in the ConfigFile
        /// </summary>
        public decimal BTWPercentage
        {
            get
            {
                return _btwPercentage;
            }
        }

        /// <summary>
        /// This function returns the price inclusive BTW rounded to 2 decimals of the given price exclusive BTW
        /// </summary>
        /// <param name="amountExclBTW">The price of which the price inclusive BTW has to be calculated</param>
        /// <returns>Returns the price inclusive BTW rounded to 2 decimals</returns>
        public decimal CalculatePriceInclusiveBTW(decimal amountExclusiveBTW)
        {
            decimal percentage = 1 + (_btwPercentage / 100);
            return Math.Round((amountExclusiveBTW * percentage), 2);
        }
        /// <summary>
        /// This function returns the price inclusive BTW rounded to 2 decimals of the given price exclusive BTW
        /// </summary>
        /// <param name="amountExclBTW">(decimal?) The price of which the price inclusive BTW has to be calculated</param>
        /// <returns>Returns the price inclusive BTW rounded to 2 decimals or 0 if amountExclusiveBTW is null</returns>
        public decimal CalculatePriceInclusiveBTW(decimal? amountExclusiveBTW)
        {
            if (amountExclusiveBTW == null)
            {
                return 0M;
            }
            else
            {

                return CalculatePriceInclusiveBTW((decimal)amountExclusiveBTW);
            }
        }
        /// <summary>
        /// This function returns the BTW rounded to 2 decimals of the given price
        /// </summary>
        /// <param name="price">The price of which the BTW has to be calculated</param>
        /// <returns>Returns the amount of BTW</returns>
        public decimal CalculateBTWOfPrice(decimal price)
        {
            decimal percentage = (_btwPercentage / 100);
            return Math.Round((price * percentage), 2);
        }

        /// <summary>
        /// This function returns the BTW rounded to 2 decimals of the given price
        /// </summary>
        /// <param name="price">(decimal?) The price of which the BTW has to be calculated</param>
        /// <returns>Returns the amount of BTW rounded to 2 decimals or 0 if price is null</returns>
        public decimal CalculateBTWOfPrice(decimal? price)
        {
            if (price == null)
            {
                return 0M;
            }
            else
            {
                return CalculateBTWOfPrice((decimal)price);
            }
        }
	    /// <summary>
        /// This function returns the price exclusive price of the given price inclusive BTW
        /// </summary>
        /// <param name="priceInclBTW">The price inclusive BTW of which the price exclusive BTW has to be calculated</param>
        /// <returns>Returns the price exclusive BTW rounded to 2 decimals</returns>
        public decimal CalculatePriceExclBTW(decimal priceInclBTW)
        {
            decimal percentage = 100M + _btwPercentage;
            return Math.Round(((priceInclBTW * 100) / percentage), 2);
        }
        /// <summary>
        /// This function returns the price exclusive price of the given price inclusive BTW
        /// </summary>
        /// <param name="priceInclBTW">(decimal?) The price inclusive BTW of which the price exclusive BTW has to be calculated</param>
        /// <returns>Returns the price exclusive BTW rounded to 2 decimals or 0 if priceInclBTW is null</returns>
        public decimal CalculatePriceExclBTW(decimal? priceInclBTW)
        {
            if (priceInclBTW == null)
            {
                return 0M;
            }
            else
            {
                return CalculatePriceExclBTW((decimal)priceInclBTW);
            }
        }
    }
}
