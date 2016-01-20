using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Case3.BSBestellingenbeheer.DAL.DataMappers
{
    public interface IDataMapper<T, TKey> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAllBy(Expression<Func<T, bool>> filter);
        T FindById(TKey id);

        T Find(TKey key);

        void Insert(T item);

        void Update(T item);

        void Delete(T item);
    }
}
