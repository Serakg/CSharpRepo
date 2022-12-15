using MindigFenyesUIModul;

namespace MindigFenyesConsoleModul_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool futas = true;
            Adataim adatok = new();
            Feladatok ujFeladat = new();
            int bejelentesSzama = 1;
            int bekertSzam;
            Console.CursorLeft = 50;
            Console.WriteLine("Mindig Fényes Kft.");
            Console.CursorLeft = 43;
            Console.WriteLine("Elvégzett munkák kiválasztása\n\n");

            var bejelentesesLista = adatok.Bejelenteseks.ToList();
            foreach (var bejelentes in bejelentesesLista)
            {
                Console.WriteLine($"{bejelentesSzama} - {bejelentes.Cim}");
                bejelentesSzama++;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Válassza ki melyik munkát végezte el! Adja meg a számát!");
            Console.WriteLine("\n");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out bekertSzam))
                {
                    Console.WriteLine("Csak számot lehet megadni!");
                }
                if (bekertSzam <= 0)
                {
                    Console.WriteLine("0-nál nagyobb számot kell megadni!");
                }
                if (bekertSzam > bejelentesesLista.Count)
                {
                    Console.WriteLine("Nincs ilyen sorszám a rendszerben!");
                }
                if (bekertSzam > 0 && bekertSzam <= bejelentesesLista.Count)
                {
                    futas = false;
                }
            }
            while (futas == true);

            Console.WriteLine("Válassza ki a szerelő nevét:");
            foreach (var szerelo in adatok.Munkas)
            {
                Console.WriteLine($"{szerelo.Nev}");
            }
            Console.WriteLine("\n");
            string kivalasztottSzerelo = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Válassza ki az elvégzett feladat típusát:");
            foreach (var tipus in adatok.FeladatTipusoks)
            {
                Console.WriteLine($"{tipus.FeladatTipus}\n");
            }

            var kivalasztottFeladatTipus = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("Adjon meg egy rövid leírást az elvégzett munkáról:");
            var feladatLeiras = Console.ReadLine();

            ujFeladat.Tipus = kivalasztottFeladatTipus;
            foreach (var munkas in adatok.Munkas)
            {
                if (munkas.Nev.TrimEnd() == kivalasztottSzerelo)
                {
                    ujFeladat.SzereloId = munkas.MunkasId;
                }
            }
            ujFeladat.Szerelo = kivalasztottSzerelo;
            ujFeladat.Leiras = feladatLeiras;
            ujFeladat.Helyszin = bejelentesesLista[SzamKivonas(bekertSzam, 1)].Cim;
            foreach (var item in adatok.Bejelenteseks)
            {
                if (item.Cim == bejelentesesLista[SzamKivonas(bekertSzam, 1)].Cim)
                {
                    ujFeladat.BejDatum = item.Idopont;
                    adatok.Bejelenteseks.Remove(item);
                }
            }
            ujFeladat.BefejezDatum = DateTime.Now;
            adatok.Feladatoks.Add(ujFeladat);
            adatok.SaveChanges();
            Console.WriteLine("\n");
            Console.WriteLine("Sikeres művelet!");
            futas = false;
        }

        public static int SzamKivonas(int elsoSzam, int masodikSzam )
        {
            return elsoSzam - masodikSzam;
        }
    }
}