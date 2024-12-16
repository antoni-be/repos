using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszeFibbonaci
{
    internal class Program
    //Napisz program, który wypisze pierwsze n liczb ciągu Fibonacciego.
    //Liczbę n podaje użytkownik.

    {
        static bool IsPrime(long n)
        {
            if (n == 0 || n == 1) { return false; }
            if (n == 2 || n == 3) { return true; }
            if (n % 2 == 0 || n % 3 == 0) { return false; }
            int d = 5;
            while (d <= Math.Sqrt(n))
            {
                if (n % d == 0) { return false; }
                d += 2;
                if (n % d == 0) { return false; }
                d += 4;
            }
            return true;
        }


        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            long n1 = 0;
            long n2 = 1;
            long ni = n1 + n2;

            for (int i = 0; i < input; i++)
            {
                n1 = n2;
                n2 = ni;
                ni = n1 + n2;
                if (IsPrime(ni))
                {
                    Console.WriteLine(ni);
                }

            }
            Console.ReadLine();
        }
    }
}
