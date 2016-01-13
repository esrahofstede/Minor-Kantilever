using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Entities;

namespace Case3.PcSWinkelen.DAL.Mappers
{
    public interface IWinkelmandDataMapper
    {
        IEnumerable<WinkelmandItem> FindAllBy(Expression<Func<WinkelmandItem, bool>> isAny);
        void AddWinkelmandItem(WinkelmandItem item);
    }
}
