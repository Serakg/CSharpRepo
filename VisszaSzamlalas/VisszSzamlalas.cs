using System;

namespace VisszaSzamlalas
{
    public class VisszSzamlalas
    {
        public DateTime Datum { get; set; }
        public string Szoveg { get; set; } = "Vakáció!";
        public VisszSzamlalas(DateTime datum)
        {
            Datum = datum;
        }

        public string MennyiMeg()
        {
            if (Datum < DateTime.Now)
            {
                return Szoveg;
            }
            return "Nem jó";
        }
    }
}
