using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


//do oczytu bazy danych :))
// https://inloop.github.io/sqlite-viewer/

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

            var Saver = new Saver();
            Saver.InitializeDatabase();


            List<string> cities = new List<string>();
            foreach (var connection in connections)
            {
                if (!cities.Contains(connection.City1)) { cities.Add(connection.City1); }
                if (!cities.Contains(connection.City2)) { cities.Add(connection.City2); }
            };

            Console.WriteLine($"Dostępne miejscowości:");
            foreach (var city in cities)
            {
                Console.Write($"{city}, ");
            }



            string start = "";
            string end = "";

            while(true)
            {
                Console.Write("\nWpisz miejscowość startową:");
                start = Console.ReadLine();
                if(cities.Contains(start)) break;
                Console.WriteLine("Miasto niedostępne, spróbuj ponownie!");
            }

            while(true)
            {
                Console.Write("Wpisz miejscowość końcową:");
                end = Console.ReadLine();
                if(cities.Contains(end)) break;
                Console.WriteLine("Miasto niedostępne, spróbuj ponownie!");
            }

            var wynik = GetShortestPath(cities, connections, start, end);
            string ShortestPathString = string.Join(", ", wynik.ShortestPath);

            Console.WriteLine($"Najkrótsza trasa z {start} do {end} to:");
            foreach(string c in wynik.ShortestPath) Console.Write($"{c} ");


            Console.WriteLine($"\nDługość trasy: {wynik.Distance} KM");

            Saver.SaveShortestRoute(start, end, string.Join(", ", wynik.ShortestPath), wynik.Distance);
            Console.WriteLine("\nPomyślnie zapisano wynik w bazie danych o nazwie results!");
            Console.WriteLine($"Ścieżka do bazy danych: {AppDomain.CurrentDomain.BaseDirectory}");
            Console.WriteLine("Skopiuj ścieżkę, a następnie");



            Console.WriteLine("Wciśnij ENTER aby zamknąć konsolę i otworzyć bazę z wynikami");
            Console.ReadKey();
            // Kod otwierający link
            string url = "https://inloop.github.io/sqlite-viewer/";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nie udało się otworzyć linku: {ex.Message}");
            }


        }



        //funkcja rekurencyjna, powtarza się do momentu aż dojdzie do korzenia, po czym zwraca korzeń
        static string FindRoot(Dictionary<string, string> parent, string city)
        {
            if (parent[city] != city)
            {
                parent[city] = FindRoot(parent, parent[city]);
            }
            return parent[city];
        }

        //metoda wykorzystywana do budowania grafu
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

        //wykorzystanie przeszukiwania wszerz (BFS) w celu znalezienia trasy o najmniejszej liczbie połączeń (dystans został zminimalizowany przy Kruskalu)
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
                    if (!visited.Contains(city))
                    { 
                        var newPath = new List<string>(path) {city};
                        queue.Enqueue(newPath);
                        visited.Add(city);
                    }
                }
            }
            return null;
        }
        static int CalculatePathDistance(List<string> path, List<Connection> connections)
        {
            int distanceSum = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                string city1 = path[i];
                string city2 = path[i+1];

                Connection connection = connections.FirstOrDefault(c =>
                    (c.City1 == city1 && c.City2 == city2) 
                    ||
                    (c.City1 == city2 && c.City2 == city1));

                //jeśli znaleziono połączenie dodajemy odległość do sumy 
                if (connection != null) distanceSum += connection.Distance;
            }
            return distanceSum;
        }

        static (List<string> ShortestPath, int Distance) GetShortestPath(List<string> cities, List<Connection> connections, string start, string end)
        {
            //wyznaczamy mst za pomocą kruskala
            List<Connection> KruskalMST = Kruskal(cities, connections);

            //budujemy graf z wyznaczonego mst
            Dictionary<string, List<string>> Graph = BuildGraph(KruskalMST);

            //wyznaczamy na grafie scieżkę z najkrótszą ilością połączeń za pomocą BFS
            List<string> shortestPath = FindPathBFS(BuildGraph(KruskalMST), start, end);

            //obliczamy długość wyznaczonej ścieżki 
            int distance = CalculatePathDistance(shortestPath, KruskalMST);

            //zwracamy wynik
            return (shortestPath, distance);
        }

    }
}
