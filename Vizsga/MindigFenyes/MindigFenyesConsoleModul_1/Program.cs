using Microsoft.Identity.Client;
using MindigFenyesUIModul;
using System.Data;
using System.Windows;

namespace MindigFenyesConsoleModul_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Adataim adatok = new();
            bool futas = true;

            Console.CursorLeft = 50;
            Console.WriteLine("Mindig Fényes Kft.");
            Console.CursorLeft = 41;
            Console.WriteLine("El nem végzett munkák lekérdezése\n\n");

            var bejelentesesLista = adatok.Bejelenteseks.ToList();
            foreach (var bejelentes in bejelentesesLista)
            {
                Console.WriteLine(bejelentes.Cim);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Adja meg, melyik irányítószámot szeretné lekérdezni!");
            Console.WriteLine("Budapesti cím esetén elég az első 3 karaktert megadni (Pl. 106 = Összes 6. kerületi cím)");
            Console.WriteLine("100 alatti érték esetén a megadott értéknél régebben bejelentett hibákat lehet lekérdezni");

            do
            {
                int iranyitoSzam;
                while (!int.TryParse(Console.ReadLine(), out iranyitoSzam))
                {
                    Console.WriteLine("Csak számot lehet megadni!");
                }
                if (iranyitoSzam <= 0)
                {
                    Console.WriteLine("0-nál nagyobb számot kell megadni!");
                }
                if (iranyitoSzam > 9999)
                {
                    Console.WriteLine("10000-nél kisebb számot kell megadni!");
                }

                var kersesEredmeny = adatok.Bejelenteseks.Where(x => x.Cim.Substring(0, 4) == iranyitoSzam.ToString()).ToList();

                if (iranyitoSzam.ToString().StartsWith('1') && iranyitoSzam.ToString().Length == 3)
                {
                    kersesEredmeny = adatok.Bejelenteseks.Where(x => x.Cim.Substring(0, 3) == iranyitoSzam.ToString().Substring(0, 3)).ToList();
                }

                if (iranyitoSzam < 100 && iranyitoSzam > 0)
                {
                    foreach (var item in adatok.Bejelenteseks)
                    {
                        if (GetNapElteres(DateTime.Now, item.Idopont) > iranyitoSzam)
                        {
                            kersesEredmeny.Add(item);
                        }
                    }
                }

                foreach (var eredmeny in kersesEredmeny)
                {
                    Console.WriteLine(eredmeny.Cim);
                }

                if (kersesEredmeny.Count == 0 && iranyitoSzam >= 100 && iranyitoSzam < 10000)
                {
                    Console.WriteLine("Nem található hibabejelentés a megadott irányítószámon!");
                }

            }
            while (futas == true);
        }

        public static double GetNapElteres(DateTime datum1, DateTime datum2)
        {
            return (datum1 - datum2).TotalDays;
        }
    }
}