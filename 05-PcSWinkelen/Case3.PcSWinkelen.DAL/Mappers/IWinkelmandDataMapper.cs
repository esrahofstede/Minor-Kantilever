﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.DAL.Mappers
{
    /// <summary>
    /// Interface for the WinkelmandDataMapper
    /// </summary>
    public interface IWinkelmandDataMapper
    {
        /// <summary>
        /// Method to retrieve WinkelmandItems by a expression
        /// </summary>
        /// <param name="isAny"></param>
        /// <returns></returns>
        IEnumerable<WinkelmandItem> FindAllBy(Expression<Func<WinkelmandItem, bool>> isAny);

        /// <summary>
        /// Method to insert a new WinkelmandItem to the database
        /// </summary>
        /// <param name="item"></param>
        void Insert(WinkelmandItem item);

        /// <summary>
        /// Method to update a given WinkelmandItem in the database
        /// </summary>
        /// <param name="updatedItem"></param>
        void Update(WinkelmandItem updatedItem);
    }
}
