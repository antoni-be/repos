using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiążkaTelefoniczna
{
    public class Kontakt
    {
        private int numerTelefonu;
        private string nazwaKontaktu;

        public int NumerTelefonu { get; set; }
        public string NazwaKontaktu { get; set; }

        public Kontakt(int NumerTelefonu, string NazwaKontaktu)
        {
            numerTelefonu = NumerTelefonu;
            nazwaKontaktu = NazwaKontaktu;
        }
        public void Display()
        {
            Console.WriteLine($"{this.NazwaKontaktu}: {this.NumerTelefonu}");
        }
    }
}
