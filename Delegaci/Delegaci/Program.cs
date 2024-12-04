using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegaci
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public int Grade { get; set; }
        }
        public class NotificationSystem
        {
            //zdarzenie, powiadomienie z wiadomoscia o wyniku
            public event Action<Student, string> MailZWynikiem;
            //lista studentów
            private List<Student> students = new List<Student>();

            public void AddStudent(Student student) => students.Add(student);
            
            //metoda do sprawdzenia wynikow
            public void CheckResults()
            {
                Random random = new Random();

                foreach (var student in students)
                {
                    student.Grade = random.Next(2, 6);

                    // wywołujemy zdarzenie dla każdego studenta na liście, sprawdzając czy sprawdzili
                    MailZWynikiem?.Invoke(student,
                        student.Grade >= 3
                            ? $"Passed! Grade: {student.Grade}"
                            : $"Failed. Grade: {student.Grade}");
                }
            }
        }

        static void Main(string[] args)
        {
            NotificationSystem egzaminCsh = new NotificationSystem();
            Student antek = new Student {Name = "antek"};
            egzaminCsh.AddStudent(antek);
            Student laura = new Student { Name = "laura" };
            egzaminCsh.AddStudent(laura);

            egzaminCsh.MailZWynikiem += (student, message) => Console.WriteLine($"Notification for {student.Name}: {message}");

            egzaminCsh.CheckResults();

            Console.ReadLine();
        }
    }
}
