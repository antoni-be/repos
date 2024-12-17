using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumFinal
{
    public abstract class Human
    {
        public bool Test(int age, bool luck, bool knowlege)
        {
            if ((age > 20 && knowlege) || (luck != false))
            {
                Console.WriteLine("Student passed exam");
                return true;
            }
            else
            {
                Console.WriteLine("Student failed exam");
                return false;
            }
        }
        public virtual void WHatToSay(){ Console.WriteLine("dont know whatto say"); }
        public virtual void SayMyName(){ Console.WriteLine("i dont have name"); }
    }
}
