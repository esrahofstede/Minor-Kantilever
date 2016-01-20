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
    /// Contract for WinkelmandDataMapper
    /// </summary>
    public interface IWinkelmandDataMapper
    {
        /// <summary>
        /// method to find winkelmanditems by expression
        /// </summary>
        /// <param name="isAny"></param>
        /// <returns></returns>
        IEnumerable<WinkelmandItem> FindAllBy(Expression<Func<WinkelmandItem, bool>> isAny);

        /// <summary>
        /// Method to insert a new winkelmanditem
        /// </summary>
        /// <param name="item"></param>
        void Insert(WinkelmandItem item);

        /// <summary>
        /// Method to update a existing winkelmanditem
        /// </summary>
        /// <param name="updatedItem"></param>
        void Update(WinkelmandItem updatedItem);

        /// <summary>
        /// Method to delete a existing winkelmanditem
        /// </summary>
        /// <param name="deleteItem"></param>
        void Delete(WinkelmandItem deleteItem);

        /// <summary>
        /// Method to find a winkelmanditem by sessieID
        /// </summary>
        /// <param name="sessieID"></param>
        /// <returns></returns>
        WinkelmandItem FindBySessieID(string sessieID);
    }
}
