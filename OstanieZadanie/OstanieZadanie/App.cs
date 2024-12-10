using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstanieZadanie
{
    public class App
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> OwnersIDs { get; set; }

        public App(int appid, string name) 
        {
            ID = appid;
            Name = name;
            OwnersIDs = new List<int>();
        }
    }
}
