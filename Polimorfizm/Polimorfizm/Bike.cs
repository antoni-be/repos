using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
    internal class Bike:Vehicle
    {
        public override int PobierzMaksPredkosc()
        {
            return 25;
            //throw new Exception("Zależy kto jedzie");
            //^ nadpisujemy metode w sposób zmieniający działanie
            //  łamiemy w ten sposób LSP
        }

        public void Jedz(string cel)
        {
            Console.WriteLine($"Jadę do {cel}");
        }
        public void Jedz(int aktualnaPredkosc)
        {
            Console.WriteLine($"Jadę z predkoscią {aktualnaPredkosc} km/h");
        }

    }
}
