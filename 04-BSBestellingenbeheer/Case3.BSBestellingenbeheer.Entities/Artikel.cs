namespace Case3.BSBestellingenbeheer.Entities
{
    public class Artikel
    {
        private string _naam;
        private string _leverancierscode;
        private string _leverancier;
        private int _aantal;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public int Aantal
        {
            get { return _aantal; }
            set { _aantal = value; }
        }

        public string Leverancierscode
        {
            get { return _leverancierscode; }
            set { _leverancierscode = value; }
        }

        public string Leverancier
        {
            get { return _leverancier; }
            set { _leverancier = value; }
        }

    }
}