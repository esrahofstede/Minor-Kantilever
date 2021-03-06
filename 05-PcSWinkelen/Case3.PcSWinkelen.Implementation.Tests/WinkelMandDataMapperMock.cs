﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    /// <summary>
    /// Mock class for WinkelMandDataMapper for testing purposes
    /// </summary>
    internal class WinkelMandDataMapperMock : IWinkelmandDataMapper
    {
        internal WinkelmandItem Item;


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

        public void DeleteBySessieID(string sessieID)
        {
            throw new NotImplementedException();
        }

        public List<WinkelmandItem> FindBySessieID(string sessieID)
        {
            throw new NotImplementedException();
        }
    }
}
