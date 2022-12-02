using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisszaSzamlalasDLL;

namespace VisszaSzamlalasFW
{
    class Program
    {
        static void Main(string[] args)
        {
            var datum = new DateTime(2022, 12, 1);
            var v = new VisszaSzamlalas(datum);
            Console.WriteLine(v.MennyiMeg());
        }
    }
}
