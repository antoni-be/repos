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
            App Visio = new App(1, "Visio");
            App SQL = new App(2, "SQL");
            App Studio = new App(3, "Studio");
            App Postman = new App(4, "Postman");

            User Karolina = new User("Karolina", 1, 11);
            Karolina.GrantAccess(4, 5, 6);
            User Ola = new User("Ola", 2, 11);
            Ola.GrantAccess(1, 2, 3);
            User Artur = new User("Artur", 3, 2);
            Artur.GrantAccess(1, 2);
            User Łukasz = new User("Łukasz", 4, 2);
            Łukasz.GrantAccess(1, 2);
            User Andrzej = new User("Łukasz", 5, 2);
            Andrzej.GrantAccess(3, 4);

            List<User> UserList = new List<User>();
            UserList.Add(Karolina);
            UserList.Add(Ola);
            UserList.Add(Artur);
            UserList.Add(Łukasz);
            UserList.Add(Andrzej);

            List<App> AppList = new List<App>();
            AppList.Add(Visio);
            AppList.Add(SQL);
            AppList.Add(Studio);
            AppList.Add(Postman);

            Console.Write("Podaj ID użytkownika któremu chcesz nadać dostęp: ");
            int UserID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj ID aplikacji do której chcesz nadać dostęp: ");
            int AppID = Convert.ToInt32(Console.ReadLine());


            foreach (var employee in UserList)
            {   //wyszukujemy pracownika
                if (employee.ID == UserID)
                {
                    //sprawdzamy kto jest menadzerem pracownika
                    int ManagerID = employee.MngID;
                    foreach (var manager in UserList)
                    {
                        if (manager.ID == ManagerID)
                        {
                            Console.WriteLine($"Wymagane zatwierdzenie od: {manager.Name}");
                        }
                    }
                }
            }
            List<User> EmployeesWithAccess = new List<User>();
            string AppSearch = "";

            //szukamy na liście aplikacji
            foreach (var app in AppList)
            {   //sprawdzamy czy ID się zgadza
                if (AppID == app.ID) 
                {   //szukamy na liście użytkowników osoby z dostępem
                    AppSearch = app.Name;
                    foreach (var admin in UserList) 
                    {
                        foreach (var accesses in admin.AccesibleApps)
                        {
                            if (admin.AccesibleApps.Contains(AppID))
                            {
                                EmployeesWithAccess.Add(admin);
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"W celu uzyskania dostępu do {AppSearch} wymagane potwierdzenie od:");
            foreach (var employee in EmployeesWithAccess) { Console.WriteLine($"{employee.Name}"); }


            Console.ReadLine();

        }
    }
}
