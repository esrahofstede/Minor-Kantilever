using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Case3.BSBestellingenbeheer.DAL.DataMappers
{
    /// <summary>
    /// Bestelling mapper class which maps Bestellingen from the database
    /// </summary>
    public class BestellingDataMapper : IDataMapper<Bestelling,long>
    {
        /// <summary>
        /// Gets bestellingen entities from the database and returns the first
        /// </summary>
        /// <param name="context"></param>
        /// <returns>The first bestelling to pack</returns>
        public Bestelling GetBestellingToPack(BestellingContext context)
        {
            return context.Bestellingen.OrderBy(b => b.BestelDatum).Include(b => b.Artikelen).FirstOrDefault();
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
            throw new NotImplementedException();
        }

        public void Update(Bestelling item)
        {
            throw new NotImplementedException();
        }
    }
}
