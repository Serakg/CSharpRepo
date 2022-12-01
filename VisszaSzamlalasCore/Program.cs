using System;
using VisszaSzamlalasDLL;

namespace VisszaSzamlalasCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var datum = new DateTime(2022, 11, 29);
            var v = new VisszaSzamlalas(datum);
            Console.WriteLine(v.MennyiMeg());
        }
    }
}
