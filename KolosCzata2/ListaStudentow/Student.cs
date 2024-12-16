using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaStudentow
{
    public class Student
    {
        public string Imie { get; set; }
        public int Indeks { get; set; }
        public Student(string imie, int wiek) 
        {
            Imie = imie;
            Indeks = wiek;
        }
    }
}
