using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student Teacher = new Student("Teacher", false, 32);
            Student Alex = new Student(true, 19);

            string teacherKnowledge = "true";
            string alexKnowledge = "false";


           bool teacherTest = Teacher.Test(Teacher.Age ,Teacher.Luck, Convert.ToBoolean(teacherKnowledge));
           bool alexTest = Alex.Test(Teacher.Age ,Teacher.Luck, Convert.ToBoolean(alexKnowledge));

            switch (teacherTest)
            {
                case true:
                    switch (alexTest)
                    {
                        case true:
                            Console.WriteLine("Knowlege and Luck matters");
                            break;
                        case false:
                            Console.WriteLine("Only Knowlege matters");
                            break;
                        default:
                            break;
                    }
                    break;                       
                case false:
                    switch (alexTest)
                    {
                        case true:
                            Console.WriteLine("Only Luck matters");
                            break;
                        case false:
                            Console.WriteLine("Nothing matters :)))))");
                            break;
                        default:
                            break;
                    }
                    break;
            }


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) Console.Write("*"); 
                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}
