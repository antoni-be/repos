using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Connection> connections = new List<Connection> 
            {
             new Connection("Kraków", "Racibórz", 420),
             new Connection("Kraków", "Wrocław", 310),
             new Connection("Kraków", "Warszawa", 500),
             new Connection("Racibórz", "Katowice", 210),
             new Connection("Katowice", "Imielin", 50),
             new Connection("Jordanów", "Kraków", 30),
             new Connection("Wrocław", "Kielce", 110),
             new Connection("Katowice", "Warszawa", 600),
             new Connection("Warszawa", "Wrocław", 430),
            };

            List<string> cities = new List<string>();
            foreach (var connection in connections)
            {
                if (!cities.Contains(connection.City1)) { cities.Add(connection.City1); }
                if (!cities.Contains(connection.City2)) { cities.Add(connection.City2); }
            };

            Console.WriteLine($"Dostępne miejscowości:");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city}");
            }

            List<Connection> KruskalMST = Kruskal(cities, connections);

            Console.WriteLine("MST:");

            foreach (Connection c in KruskalMST)
            {
                Console.WriteLine($"{c.City1}:{c.City2} {c.Distance}KM");
            }

            
            Console.ReadKey();
        }



        static List<Connection> Kruskal(List<string> cities, List<Connection> connections) 
        {
            List<Connection> mst = new List<Connection>();

            Dictionary<string, string> parent = cities.ToDictionary(city => city, city => city);
            connections.Sort((c1, c2) => c1.Distance.CompareTo(c2.Distance));

            foreach (var connection in connections)
            {
                string root1 = FindRoot(parent, connection.City1);
                string root2 = FindRoot(parent, connection.City2);

                if (root1 != root2)
                {
                    mst.Add(connection);
                    parent[root1] = root2;
                }
                    
            }

            return mst;
        }
        static string FindRoot(Dictionary<string, string> parent, string city)
        {
            if (parent[city] != city)
            {
                parent[city] = FindRoot(parent, parent[city]);
            }
            return parent[city];
        }
    }
}
