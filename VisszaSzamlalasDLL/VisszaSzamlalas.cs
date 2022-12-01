using System;

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
            
        }
    }
}
