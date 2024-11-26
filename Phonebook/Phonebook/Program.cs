using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
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

        static void ReadAndClear(string message)
        {
            Console.Write(message);
            Console.ReadLine();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            //tworzę nowy obiekt klasy książkaTelefoniczna i dodaje przykładowe kontakty
            KsiazkaTelefoniczna ksiazkaTelefoniczna = new KsiazkaTelefoniczna();
            ksiazkaTelefoniczna.DodajKontakt(new Kontakt(123456789, "Piotrek"));
            ksiazkaTelefoniczna.DodajKontakt(new Kontakt(439234694, "Rafał"));
            ksiazkaTelefoniczna.DodajKontakt(new Kontakt(423529291, "Marysia"));

            Console.WriteLine("Witaj w Książce telefonicznej!");
            bool ProgramStatus = true;
            while (ProgramStatus)
            {
                WyswietlMenu();
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        try
                        {
                            Console.Write("Podaj nazwę nowego kontaktu: ");
                            string nazwa = Console.ReadLine();
                            Console.Write("Podaj numer telefonu: ");
                            int numer = Convert.ToInt32(Console.ReadLine());

                            Kontakt NowyKontakt = new Kontakt(numer, nazwa);
                            ksiazkaTelefoniczna.DodajKontakt(NowyKontakt);

                            ReadAndClear("Kontakt dodany pomyślnie, wciśnij ENTER aby wrócić do menu...");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Niepowodzenie: {e.Message}");
                            ReadAndClear("Wciśnij ENTER aby wrócić do menu i spróbować ponownie...");
                        }
                        break;

                    case "2":
                        Console.Write("Podaj numer telefonu, który chcesz wyszukać: ");
                        input = Console.ReadLine();
                        try
                        {
                            ksiazkaTelefoniczna.WyswietlKontakt(Convert.ToInt32(input));
                            ReadAndClear("Wciśnij ENTER aby wrócić do menu...");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Niepowodzenie: {e.Message}");
                        }
                         break;

                    case "3":
                        Console.Write("Podaj nazwę kontaktu, który chcesz wyszukać: ");
                        input = Console.ReadLine();
                        ksiazkaTelefoniczna.WyswietlKontakt(input);
                        ReadAndClear("Wciśnij ENTER aby wrócić do menu...");
                        break;

                    case "4":
                        ksiazkaTelefoniczna.WyswietlKontakty();
                        ReadAndClear("Wciśnij ENTER żeby wrócić do menu...");
                        break;

                    case "5":
                        Console.WriteLine("Kliknij ENTER aby potwierdzić zamknięcie programu...");
                        Console.ReadLine();
                        ProgramStatus = false;
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
