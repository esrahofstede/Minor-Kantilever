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
    public class WinkelmandDataMapper : IWinkelmandDataMapper
    {
        public IEnumerable<WinkelmandItem> FindAllBy(Expression<Func<WinkelmandItem, bool>> isAny)
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.Where(isAny).ToList();
            }
        }

        public void Insert(WinkelmandItem item)
        {
            using (var context = new WinkelmandContext())
            {
                context.WinkelmandItems.Add(item);
                context.SaveChanges();
            }
        }

        public void Update(WinkelmandItem updatedItem)
        {
            using (var context = new WinkelmandContext())
            {
                var oldItem = context.WinkelmandItems.Find(updatedItem.ID);
                context.Entry(oldItem).CurrentValues.SetValues(updatedItem);
                context.SaveChanges();
            }
        }

        public IEnumerable<WinkelmandItem> FindAll()
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.ToList();
            }
        }

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

        public WinkelmandItem FindBySessieID(string sessieID)
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.Where(x => x.SessieID == sessieID).FirstOrDefault();
            }
        }
    }
}
