using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hasło
{
    internal class Program
    {
        //5. Walidacja hasła
        //Napisz program, który sprawdza, czy hasło podane przez użytkownika spełnia następujące warunki:

            //Ma co najmniej 8 znaków,
            //Zawiera przynajmniej jedną wielką literę,
            //Zawiera przynajmniej jedną cyfrę.

        //Jeśli hasło spełnia wszystkie warunki, wyświetl odpowiedni komunikat.


        static void Main(string[] args)
        {
            Console.Write("Wprowadź Hasło: ");
            string input = Console.ReadLine();

            bool Num = false;
            bool BigLetter = false;

            foreach (char i in input)
            {
                if (char.IsDigit(i)) Num = true;
                if (char.IsUpper(i)) BigLetter = true;
                if (Num && BigLetter) break;
            }

            if (input.Length < 8) Console.WriteLine("Warunek: Hasło powinno zawierać co najmniej 8 znaków.");
            if (!Num) Console.WriteLine("Warunek: Hasło musi zawierać minimum 1 cyfrę.");
            if (!BigLetter) Console.WriteLine("Warunek: Hasło musi zawierać minimum 1 wielką literę.");

            else 
            {
                Console.WriteLine("Hasło zapisane pomyślnie!");
            }

            Console.ReadKey();
        }
    }
}
