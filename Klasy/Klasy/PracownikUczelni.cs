using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasy
{
    public class PracownikUczelni : Człowiek
    {
        private string Wykształcenie { get; }
        private string Imie { get; }
        private string Nazwisko { get; }

        public PracownikUczelni(string wykształcenie, string imie, string nazwisko) 
        {
            Wykształcenie = wykształcenie;
            Imie = imie;
            Nazwisko = nazwisko;

        }

        public override void Spoznienie()
        {
            Console.WriteLine($"{this.Imie}: Dzień dobry, przepraszam za spóźnienie");
        }
    }
}
