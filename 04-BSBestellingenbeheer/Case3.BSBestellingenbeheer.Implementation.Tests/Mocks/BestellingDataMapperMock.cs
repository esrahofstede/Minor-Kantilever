using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSBestellingenbeheer.Entities;

namespace Case3.BSBestellingenbeheer.Implementation.Tests.Mocks
{
    public class BestellingDataMapperMock : IDataMapper<Bestelling, long>
    {
        private List<Bestelling> _list = new List<Bestelling>();

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public void Delete(Bestelling item)
        {
            throw new NotImplementedException();
        }

        public Bestelling Find(long key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bestelling> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bestelling> FindAllBy(Expression<Func<Bestelling, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Bestelling FindById(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Bestelling item)
        {
            _list.Add(item);
        }

        public void Update(Bestelling item)
        {
            throw new NotImplementedException();
        }
    }
}
