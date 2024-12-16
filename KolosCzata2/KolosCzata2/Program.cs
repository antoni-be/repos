using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolosCzata2
{
    internal class Program
    {
        //Napisz program, który oblicza średnią ważoną ocen.
        //Pobierz od użytkownika liczby reprezentujące oceny i odpowiadające im wagi,
        //aż użytkownik wpisze -1, aby zakończyć wprowadzanie.
        //Następnie oblicz i wyświetl średnią ważoną.


        static void Main(string[] args)
        {
            List<int[]> oceny = new List<int[]>();
            Console.Write("Podaj ocenę: ");
            int ocena = int.Parse(Console.ReadLine());
            Console.Write("Podaj wagę: ");
            int waga = int.Parse(Console.ReadLine());

            //wprowadzanie
            while (ocena != -1 && waga != -1)
            {
                int[] para = new int[2];
                para[0] = ocena;
                para[1] = waga;
                oceny.Add(para);
                Console.Write("Podaj ocenę: ");
                ocena = int.Parse(Console.ReadLine()) ;
                Console.Write("Podaj wagę: ");
                waga = int.Parse(Console.ReadLine()) ;
            }

            //obliczanie sredniej
            decimal TotalSum = 0;
            decimal TotalWeight = 0;
            foreach (var a in oceny)
            {
                //suma oceny
                TotalSum += a[0] * a[1];
                TotalWeight += a[1];
            }
            Console.WriteLine(TotalSum/TotalWeight);
            Console.ReadLine();
        }
    }
}
