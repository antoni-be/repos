using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KsiążkaTelefoniczna
{
    public class KsiazkaTelefoniczna
    {
        private List<Kontakt> kontakty { get; set; } = new List<Kontakt> { };
        private void WyswietlKontakt(Kontakt kontakt) { Console.WriteLine($"Kontakt: {kontakt.NazwaKontaktu}: {kontakt.NumerTelefonu}"); }

        private void WyswietlKontakty(List<Kontakt> kontakty)
        {
            foreach (Kontakt kontakt in kontakty)
            {
                WyswietlKontakt(kontakt);
            }
        }
        public void DodajKontakt(Kontakt nowyKontakt)
        {
            kontakty.Add(nowyKontakt);
        }
        public void WystwietlKontakty() 
        {
            WyswietlKontakty(kontakty);
        }
    }
}
