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

            List<string> ShortestPath = FindPathBFS(BuildGraph(KruskalMST), "Kraków", "Racibórz");
            Console.WriteLine("Najkrótsza droga z krk do src to:");
            Console.WriteLine();
            foreach (string c in ShortestPath) Console.WriteLine($"{c}KM");
            
            
            Console.ReadKey();
        }
        //funkcja rekurencyjna, powtarza się do momentu aż dojdzie do korzenia, po czym zwraca korzen
        static string FindRoot(Dictionary<string, string> parent, string city)
        {
            if (parent[city] != city)
            {
                parent[city] = FindRoot(parent, parent[city]);
            }
            return parent[city];
        }

        static Dictionary<string, List<string>> BuildGraph(List<Connection> connections)
        {
            //tworzymy pusty slownik na którym będziemy budować nasz graf
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            foreach (Connection connection in connections)
            {
                //jesli słownik graph nie zawiera jeszcze w kluczach miasta1 lub miasta2, dodajemy je z pustą listą
                if (!graph.ContainsKey(connection.City1)) graph[connection.City1] = new List<string>();
                if (!graph.ContainsKey(connection.City2)) graph[connection.City2] = new List<string>();


                //dodajemy połączenie w obie strony
                graph[connection.City1].Add(connection.City2);
                graph[connection.City2].Add(connection.City1);
            }

            return graph;
        }

        //algorytm krusaka
        static List<Connection> Kruskal(List<string> cities, List<Connection> connections) 
        {
            //tworzymy pusta liste w ktorej bedziemy zapisywac minimum spanning tree
            List<Connection> mst = new List<Connection>();

            //tworzymy slownik w ktorym do kazdego miasta przypisujemy je same, dzieki czemu jestesy pozniej w stanie znalezc korzen kazdego miasta
            Dictionary<string, string> parent = cities.ToDictionary(city => city, city => city);

            //sortujemy wszystkie polaczenia wg najkrótszego dystansu
            connections.Sort((c1, c2) => c1.Distance.CompareTo(c2.Distance));

            //przechodzimy przez posortowana liste wszystkich polaczen 
            foreach (var connection in connections)
            {
                //szukamy dla kazdego polaczenia korzenia obu miast
                string root1 = FindRoot(parent, connection.City1);
                string root2 = FindRoot(parent, connection.City2);

                //jesli korzenie sa rozne, dodajemy polaczenie do mst, pozwala nam to uniknąć zapętlania się połązczeń
                if (root1 != root2)
                {
                    mst.Add(connection);
                    parent[root1] = root2;
                }
                    
            }

            return mst;
        }

        //wykorzystanie przeszukiwania wszerz w celu znalezienia trasy o najmniejszej liczbie połączeń (dystans został zminimalizowany przy Kruskalu)
        static List<string> FindPathBFS(Dictionary<string, List<string>> graph, string start, string end)
        {
            Queue<List<string>> queue = new Queue<List<string>>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(new List<string> {start});
            visited.Add(start);

            while (queue.Count > 0)
            { 
                var path = queue.Dequeue();
                var lastInPath = path.Last();

                if (lastInPath == end) return path;

                foreach (var city in graph[lastInPath])
                {
                    if (visited.Contains(city))
                    { 
                        var newPath = new List<string>(path) {city};
                        queue.Enqueue(newPath);
                        visited.Add(city);
                    }
                }
            }
            return null;
        }

    }
}
