using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudentow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kierunek IFS = new Kierunek("Informatyka Społeczna");

            IFS.DodajStudenta(new Student("antek", 420420));
            IFS.DodajStudenta(new Student("kasia", 2123421));
            IFS.DodajStudenta(new Student("luara", 420420));
            IFS.DodajStudenta(new Student("antena", 123321));

            IFS.WyszukajStudenta("ant");
            Console.WriteLine();
            IFS.WyszukajStudenta(420420);


            Console.ReadKey();  
        }
    }
}
