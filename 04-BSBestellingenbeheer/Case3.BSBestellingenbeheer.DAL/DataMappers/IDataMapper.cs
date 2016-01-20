using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Case3.BSBestellingenbeheer.DAL.DataMappers
{
    public interface IDataMapper<T, TKey> where T : class
    {
        void Insert(T item);
    }
}
