using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudentow
{
    public class Kierunek
    {
        public string Nazwa { get; set; }
        public List<Student> ListaStudentow = new List<Student>();

        public Kierunek(string nazwa) 
        {
           Nazwa = nazwa;
        }

        public void DodajStudenta(Student nowy)
        { 
            ListaStudentow.Add(nowy);
        }

        public void WyszukajStudenta(string imie)
        {
            foreach (Student s in ListaStudentow) if (s.Imie.Contains(imie)) Console.WriteLine($"{s.Imie}: {s.Indeks}");
        }
        public void WyszukajStudenta(int indeks) 
        {
            foreach (Student s in ListaStudentow) if (s.Indeks == indeks) Console.WriteLine($"{s.Imie}: {s.Indeks}");
        }

    }
}
