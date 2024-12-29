using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    public class Connection
    {
        public string City1 { get; }
        public string City2 { get; }
        public int Distance { get; }

        public Connection(string city1, string city2, int distance)
        {
            City1 = city1;
            City2 = city2;  
            Distance = distance;
        }

    }

}
