using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    internal class WinkelMandDataMapperMock : IWinkelmandDataMapper
    {
        internal WinkelmandItem Item;

        public void Delete(WinkelmandItem deleteItem)
        {
            throw new NotImplementedException();
        }

        public WinkelmandItem FindBySessieID(string sessieID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WinkelmandItem> FindAllBy(Expression<Func<WinkelmandItem, bool>> isAny)
        {
            throw new NotImplementedException();
        }

        public void Insert(WinkelmandItem item)
        {
            Item = item;
        }

        public void Update(WinkelmandItem item)
        {
            throw new NotImplementedException();
        }
    }
}
