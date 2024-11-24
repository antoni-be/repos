using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KsiazkaTelefoniczna
{
    private List<Kontakt> listaKontakty = new List<Kontakt>();


    public void WyswietlKontakty()
    {
        if (listaKontakty == null || listaKontakty.Count == 0)
        {
            Console.WriteLine("Lista kontaktów jest pusta");
        }
        else
        {
            foreach (var kontakt in listaKontakty)
            {
                kontakt.Display();
            }
        }
    }


    public void DodajKontakt(Kontakt nowyKontakt)
    {
        listaKontakty.Add(nowyKontakt);
    }


    public void WyswietlKontakt(int numerTelefonu)
    {
        var kontakt = listaKontakty.FirstOrDefault(w => w.NumerTelefonu == numerTelefonu);
        if (kontakt == null)
        {
            Console.WriteLine("Nie odnaleziono kontaktu.");
        }
        else
        {
            kontakt.Display();
        }
    }
    public void WyswietlKontakt(string nazwaKontaktu)
    {
        var kontakt = listaKontakty.FirstOrDefault(w => w.NazwaKontaktu.ToLower() == nazwaKontaktu.ToLower());
        if (kontakt == null)
        {
            Console.WriteLine("Nie odnaleziono kontaktu.");
        }
        else
        {
            kontakt.Display();
        }
    }
}
