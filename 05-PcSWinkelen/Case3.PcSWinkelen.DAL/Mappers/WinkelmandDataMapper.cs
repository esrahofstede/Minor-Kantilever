using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Contexts;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.DAL.Mappers
{
    /// <summary>
    /// Mapper class to map the Winkelmand entities to the database
    /// </summary>
    public class WinkelmandDataMapper : IWinkelmandDataMapper
    {
        /// <summary>
        /// Method to find all WinkelmandItem by a expression
        /// </summary>
        /// <param name="isAny"></param>
        /// <returns></returns>
        public IEnumerable<WinkelmandItem> FindAllBy(Expression<Func<WinkelmandItem, bool>> isAny)
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.Where(isAny).ToList();
            }
        }


        /// <summary>
        /// Method to insert a WinkelmandItem
        /// </summary>
        /// <param name="item">WinkelmandItem which needs to be inserted</param>
        public void Insert(WinkelmandItem item)
        {
            using (var context = new WinkelmandContext())
            {
                context.WinkelmandItems.Add(item);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update a WinkelmandItem in the database
        /// </summary>
        /// <param name="updatedItem">WinkelmandItem which needs to be updated</param>
        public void Update(WinkelmandItem updatedItem)
        {
            using (var context = new WinkelmandContext())
            {
                if (updatedItem != null)
                {
                    var oldItem = context.WinkelmandItems.Find(updatedItem.ID);
                    context.Entry(oldItem).CurrentValues.SetValues(updatedItem);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to retrieve all the WinkelmandItems from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WinkelmandItem> FindAll()
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.ToList();
            }
        }
    }
}
