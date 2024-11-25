using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
    internal class Car:Vehicle
    {
        public override int PobierzMaksPredkosc()
        {
            return 220;
        }
    }
}
