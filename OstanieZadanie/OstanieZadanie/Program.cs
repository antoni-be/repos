using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstanieZadanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 1. wybieramy ID uzytkownika
             * 2. wybieramy ID aplikacji
             * 3. wyliaczmy workflow:
             *     a. jaki menadzer musi zatwierdzić
             *     b. kto może nadać dostęp do aplikacji
             */
            List<User> UserList = new List<User>();
            List<App> AppList = new List<App>();


            App Visio = new App(1, "Visio");
            AppList.Add(Visio);

            App SQL = new App(2, "SQL");
            AppList.Add(SQL);

            App Studio = new App(3, "Studio");
            AppList.Add(Studio);

            App Postman = new App(4, "Postman");
            AppList.Add(Postman);


            User Karolina = new User("Karolina", 1, 11);
            Karolina.GrantAccess(4, 5, 6);
            UserList.Add(Karolina);

            User Ola = new User("Ola", 2, 11);
            Ola.GrantAccess(1, 2, 3);
            UserList.Add(Ola);

            User Artur = new User("Artur", 3, 2);
            Artur.GrantAccess(1, 2);
            UserList.Add(Artur);

            User Łukasz = new User("Łukasz", 4, 2);
            Łukasz.GrantAccess(1, 2);
            UserList.Add(Łukasz);

            User Andrzej = new User("Łukasz", 5, 2);
            Andrzej.GrantAccess(3, 4);
            UserList.Add(Andrzej);

            User Wiktor = new User("Wiktor", 6, 2);
            Wiktor.GrantAccess(3, 4);
            UserList.Add(Wiktor);

            User Rafał = new User("Rafał", 7, 1);
            Rafał.GrantAccess(5, 6);
            UserList.Add(Rafał);

            User Michał = new User("Michał", 8, 1);
            Michał.GrantAccess(5, 6);
            UserList.Add(Michał);

            User Damian = new User("Damian", 9, 1);
            UserList.Add(Damian);

            User Paweł = new User("Paweł", 10, 1);
            UserList.Add(Paweł);

            User Steven = new User("Steven", 11, 99);
            UserList.Add(Steven);



            Console.Write("Podaj ID użytkownika któremu chcesz nadać dostęp: ");
            int UserID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj ID aplikacji do której chcesz nadać dostęp: ");
            int AppID = Convert.ToInt32(Console.ReadLine());

            User SearchedUser = UserList.FirstOrDefault(user => user.ID == UserID);
            if (SearchedUser != null)
            {
                User Manager = UserList.FirstOrDefault(manager => manager.ID.Equals(SearchedUser.MngID));
                if (Manager != null)
                {
                    Console.WriteLine($"Wymagane zatwierdzenie od mendadżera: {Manager.Name}");
                }
                else { Console.WriteLine("Error: Nie przypisano menadżerki!"); }
            }
            else { Console.WriteLine("Error: Nie odnaleziono użytkownika o takim ID w bazie!"); }

            /*foreach (var employee in UserList)
            {   //wyszukujemy pracownika
                if (employee.ID == UserID)
                {
                    //sprawdzamy kto jest menadzerem pracownika
                    int ManagerID = employee.MngID;
                    foreach (var manager in UserList)
                    {
                        if (manager.ID == ManagerID)
                        {
                            Console.WriteLine($"Wymagane zatwierdzenie od menadżerki: {manager.Name}");
                        }
                    }
                }
            }*/

            List<User> RequiredAccess = UserList.Where(admin => admin.AccesibleApps.Contains(AppID)).ToList();
            Console.WriteLine("Wymagana przydzielenie licencji przez jednego z administratorów:");
            foreach (var admin in RequiredAccess) { Console.WriteLine($"- {admin.Name}"); }

            Console.ReadLine();

        }
    }
}
