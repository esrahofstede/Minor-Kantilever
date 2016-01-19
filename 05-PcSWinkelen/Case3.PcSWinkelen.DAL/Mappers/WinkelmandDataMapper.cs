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

        public void Update(WinkelmandItem item)
        {
            using (var context = new WinkelmandContext())
            {
                if (item != null)
                {
                    var oldItem = context.WinkelmandItems.Find(item.ID);
                    context.Entry(oldItem).CurrentValues.SetValues(item);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<WinkelmandItem> FindAll()
        {
            using (var context = new WinkelmandContext())
            {
                return context.WinkelmandItems.ToList();
            }
        }
    }
}
