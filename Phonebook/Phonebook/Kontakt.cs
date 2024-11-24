using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Kontakt
{
    private int numerTelefonu;
    private string nazwaKontaktu;


    public Kontakt(int numerTelefonu, string nazwaKontaktu)
    {
        this.numerTelefonu = numerTelefonu;
        this.nazwaKontaktu = nazwaKontaktu;
    }

    public int NumerTelefonu
    {
        get { return numerTelefonu; }
    }

    public string NazwaKontaktu
    {
        get { return nazwaKontaktu; }
    }


    public void Display()
    {
        Console.WriteLine($"{NazwaKontaktu}: {NumerTelefonu}");
    }
}
