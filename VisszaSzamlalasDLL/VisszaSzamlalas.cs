using System;
using System.Linq;

namespace VisszaSzamlalasDLL
{
    public class VisszaSzamlalas
    {
        public DateTime Datum { get; set; }
        public string Szoveg { get; set; } = "Vakáció!";

        public VisszaSzamlalas(DateTime datum)
        {
            Datum = datum;
        }

        public string MennyiMeg()
        {
            int napKulonseg = int.Parse(Datum.Subtract(DateTime.Now.Date).Days.ToString());
            switch (napKulonseg)
            {
                case 0: return Szoveg;
                case -1: return Szoveg.Substring(1);
                case -2: return Szoveg.Substring(2); ;
                case -3: return Szoveg.Substring(3); ;
                case -4: return Szoveg.Substring(4); ;
                case -5: return Szoveg.Substring(5); ;
                case -6: return Szoveg.Substring(6); ;
                case -7: return Szoveg.Substring(7); ;
            }
            if (napKulonseg > 0)
            {
                return Szoveg;
            }
            if (napKulonseg < -7)
            {
                return "Hol van az még!";
            }
            return Szoveg;
        }
    }
}
