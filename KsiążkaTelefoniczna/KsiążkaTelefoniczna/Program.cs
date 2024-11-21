using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiążkaTelefoniczna
{
    internal class Program
    {
        static void WyswietlMenu() 
        {
            Console.WriteLine("Wybierz co chcesz zrobić:");
            Console.WriteLine("1. Dodaj nowy kontakt");
            Console.WriteLine("2. Wyszukaj kontakt na podstawie numeru");
            Console.WriteLine("3. Wyszukaj kontakt na podstawie nazwy kontaktu");
            Console.WriteLine("4. Wyświetl wszystkie kontakty");
            Console.WriteLine("5. Opuść program");
        }
        static void Main(string[] args)
        {
            /*
             *Wyświetlamy menu w którym możemy wybrać jedno z czterech działań:
             * 1. dodać kontakt
             * 2. wyświetlić kontakt na podstawie nr telefonu
             * 3. wyświetlić wszystkie kontakty
             * 4. wyszukać kontakt na podstawie imienia
             */
            KsiazkaTelefoniczna ksiazkaTelefoniczna = new KsiazkaTelefoniczna();
            Kontakt przykładowy1 = new Kontakt(420420420, "przykładowy1");
            ksiazkaTelefoniczna.DodajKontakt(przykładowy1);
            Kontakt przykładowy2 = new Kontakt(123456789, "przykładowy2");
            ksiazkaTelefoniczna.DodajKontakt(przykładowy2);
            Kontakt przykładowy3 = new Kontakt(987654321, "przykładowy3");
            ksiazkaTelefoniczna.DodajKontakt(przykładowy3);

            Console.WriteLine("Witaj w Książce telefonicznej!");
            WyswietlMenu();
            string input = Console.ReadLine();
            switch (input) 
            {
                case "1":
                    Console.Write("Podaj nazwę nowego kontaktu: ");
                    string nazwa = Console.ReadLine();
                    Console.Write("Podaj numer telefonu: ");
                    int numer = Convert.ToInt32(Console.ReadLine());

                    Kontakt NowyKontakt = new Kontakt(numer, nazwa);
                    NowyKontakt.Display();
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":
                    ksiazkaTelefoniczna.WystwietlKontakty();
                    break;
                case "5":
                    
                    break;
                default:
                    Console.WriteLine("Nieprawidłowe dane wejściowe.");
                    break;

            }


            Console.ReadKey();  

        }
    }
}
