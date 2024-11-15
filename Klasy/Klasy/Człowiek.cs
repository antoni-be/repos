using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public class Człowiek 
    {
        private int wiek { get; set; }
        private string imie{ get; set; }

        public void Stand()
        {
            Console.WriteLine("wstałem");
        }

        public virtual void Spoznienie() { }

    }
}
