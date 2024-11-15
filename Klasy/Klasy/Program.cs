using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student Antek = new Student(409966);

            Antek.Stand();
            Antek.Zajecia();

            PracownikUczelni Wykładowca = new PracownikUczelni("Jan", "Kowalski", "Doktor Habilitowany Eminencja ");

            Wykładowca.Spoznienie();

            Console.ReadLine();
        }
    }
}
