using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.Entities
{
    public class Bestelling
    {
        private long _id;
        private DateTime _bestelDatum;
        private List<Artikel> _artikellen;

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime BestelDatum
        {
            get { return _bestelDatum; }
            set { _bestelDatum = value; }
        }


        public List<Artikel> Artikellen
        {
            get { return _artikellen; }
            set { _artikellen = value; }
        }


    }
}
