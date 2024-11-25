using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
    internal class Vehicle
    {
        public virtual int PobierzMaksPredkosc()
        {
            return 100;
        }
        public virtual void Jedz()
        {
            Console.WriteLine($"Rozpędzam się do predkosci {PobierzMaksPredkosc()}");
        }
    }
}
