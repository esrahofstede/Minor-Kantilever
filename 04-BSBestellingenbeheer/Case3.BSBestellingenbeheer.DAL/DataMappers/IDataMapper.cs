using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Case3.BSBestellingenbeheer.DAL.DataMappers
{
    /// <summary>
    /// The generic datamapper
    /// </summary>
    /// <typeparam name="T">The item</typeparam>
    /// <typeparam name="TKey">The key of the item</typeparam>
    public interface IDataMapper<T, TKey> where T : class
    {
        /// <summary>
        /// Inserts a new item
        /// </summary>
        /// <param name="item">The item to insert</param>
        void Insert(T item);
    }
}
