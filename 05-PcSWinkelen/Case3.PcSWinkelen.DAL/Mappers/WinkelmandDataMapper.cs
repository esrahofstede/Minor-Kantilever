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
    /// DataMapper for the Winkelmand entity
    /// </summary>
    public class WinkelmandDataMapper : IWinkelmandDataMapper
    {
        /// <summary>
        /// Retrieves all the winkelmanditem entities which satisfy the given expression
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
        /// Adds the given winkelmanditem to the database
        /// </summary>
        /// <param name="item"></param>
        public void Insert(WinkelmandItem item)
        {
            using (var context = new WinkelmandContext())
            {
                context.WinkelmandItems.Add(item);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the given winkelmanditem in the database
        /// </summary>
        /// <param name="updatedItem"></param>
        public void Update(WinkelmandItem updatedItem)
        {
            using (var context = new WinkelmandContext())
            {
                var oldItem = context.WinkelmandItems.Find(updatedItem.ID);
                context.Entry(oldItem).CurrentValues.SetValues(updatedItem);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves a list of all the winkelmandItems found in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WinkelmandItem> FindAll()
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.ToList();
            }
        }

        /// <summary>
        /// Deletes the given winkelmanditem in the database
        /// </summary>
        /// <param name="deleteItem"></param>
        public void Delete(WinkelmandItem deleteItem)
        {
            using (var context = new WinkelmandContext())
            {
                var result = context.WinkelmandItems.Where(x => x.SessieID == deleteItem.SessieID).FirstOrDefault();

                if (result != null)
                {
                    context.WinkelmandItems.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Retrieves a single winkelmandItem by sessieID
        /// </summary>
        /// <param name="sessieID"></param>
        /// <returns></returns>
        public WinkelmandItem FindBySessieID(string sessieID)
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.Where(x => x.SessieID == sessieID).FirstOrDefault();
            }
        }
    }
}
