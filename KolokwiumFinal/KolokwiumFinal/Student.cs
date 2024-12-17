using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumFinal
{
    public class Student : Human
    {
        public string Name { get; private set; }
        public bool Luck { get; private set; }
        public int Age { get; private set; }

        public Student(string name, bool luck, int age)
        {
            Name = name;
            Luck = luck;
            Age = age;
        }
        public Student(bool luck, int age)
        {
            Luck = luck;
            Age = age;
        }

        public override void SayMyName()
        {
            Console.WriteLine(Name);
        }
    }
}
