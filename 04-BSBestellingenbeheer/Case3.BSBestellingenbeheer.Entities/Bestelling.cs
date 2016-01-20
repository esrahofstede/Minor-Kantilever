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
        private int _status;
        private List<Artikel> _artikelen;

        private int _BTWPercentage;
        private decimal _totaalPrijs;

        private string _klantNaam;
        private string _adresregel1;
        private string _adresregel2;
        private string _postcode;
        private string _woonplaats;
        private string _telefoonnummer;

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

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public virtual List<Artikel> Artikelen
        {
            get { return _artikelen; }
            set { _artikelen = value; }
        }

        public int BTWPercentage
        {
            get { return _BTWPercentage; }
            set { _BTWPercentage = value; }
        }

        public decimal TotaalPrijs
        {
            get { return _totaalPrijs; }
            set { _totaalPrijs = value; }
        }

        public string KlantNaam
        {
            get { return _klantNaam; }
            set { _klantNaam = value; }
        }

        public string AdresRegel1
        {
            get { return _adresregel1; }
            set { _adresregel1 = value; }
        }
        public string AdresRegel2
        {
            get { return _adresregel2; }
            set { _adresregel2 = value; }
        }

        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        public string Woonplaats
        {
            get { return _woonplaats; }
            set { _woonplaats = value; }
        }

        public string Telefoonnummer
        {
            get { return _telefoonnummer; }
            set { _telefoonnummer = value; }
        }
    }
}
