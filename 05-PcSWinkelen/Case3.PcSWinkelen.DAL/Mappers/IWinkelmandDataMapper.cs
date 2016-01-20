using Case3.PcSWinkelen.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        /// <summary>
        /// Retrieves a single winkelmandItem by sessieID
        /// </summary>
        /// <param name="sessieID">The Id of the Session of which the WinkelmandItems need to be removed</param>
        void DeleteBySessieID(string sessieID);

        /// <summary>
        /// Retrieves a List of WinkelmandItems based on a SessionID
        /// </summary>
        /// <param name="sessieID">The Id of the Session of which the WinkelmandItems need to be found</param>
        /// <returns>Returns a List of WinkelmandItems</returns>
        List<WinkelmandItem> FindBySessieID(string sessieID);
    }
}
