using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortowanieOsób
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> osoby = new List<Person> 
            {
                new Person("antek", 22),
                new Person("gosia", 21),
                new Person("klaudia", 13),
                new Person("artur", 32)
            };


            foreach (Person osoba in osoby)
            {
                Console.WriteLine($"{osoba.Name}: {osoba.Age}");
            }

            osoby.Sort((o1, o2) => o1.Age.CompareTo(o2.Age));
            
            Console.WriteLine("Posortowana lista:");
            foreach (Person osoba in osoby)
            {
                Console.WriteLine($"{osoba.Name}: {osoba.Age}");
            }
            
            
            
            
            Console.ReadLine();
        }
    }
}
