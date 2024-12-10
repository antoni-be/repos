using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstanieZadanie
{
    public class User
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int MngID { get; set; }
        public List<int> AccesibleApps { get; set; }
        public User(string name, int id, int mngid) 
        {
            Name = name;
            ID = id;
            MngID = mngid;
            AccesibleApps = new List<int>();
        }
        public void GrantAccess(int App1ID) 
        {
            AccesibleApps.Add(App1ID);
        }
        public void GrantAccess(int App1ID, int App2ID) 
        {
            AccesibleApps.Add(App1ID);
            AccesibleApps.Add(App2ID);
        }
        public void GrantAccess(int App1ID, int App2ID, int App3ID) 
        {
            AccesibleApps.Add(App1ID);
            AccesibleApps.Add(App2ID);
            AccesibleApps.Add(App3ID);
        }
    }
}
