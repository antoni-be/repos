using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public class Student : Człowiek
    {
        private int NumerIndeksu { get; set; }
        public Student(int numerIndeksu)
        {
            NumerIndeksu = numerIndeksu;
        }

        public void Zajecia()
        {
            Console.WriteLine("ide na zajecia");
        }
    }
}
