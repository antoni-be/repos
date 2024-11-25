using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfizm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bike rower = new Bike();
            Car samochod = new Car();

            List<Vehicle> garaz = new List<Vehicle> { rower, samochod };

            foreach (Vehicle vehicle in garaz)
            {
                vehicle.Jedz();
            }

            Console.WriteLine();

            rower.Jedz();         // Polimorfizm dynamiczny: metoda z klasy bazowej

            rower.Jedz("sklepu"); // Polimorfizm statyczny: 
            rower.Jedz(10);       // Polimorfizm statyczny: 

            Console.ReadLine();
        }

    }
}
