using System;
using System.Collections.Generic;
using System.Linq;

//Изучение проекций
namespace Linq_Practice_5
{

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}, Age: {Age}";
        }
    }



    class Program
    {
        private static void SelectNamesWithLinq()
        {
            Console.WriteLine("Выбираем свойство объекта с помощью линка:");
            List<User> users = new List<User>();
            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            Console.WriteLine();
            Console.WriteLine("Исходный массив: ");

            foreach (User user in users)
            {
                Console.WriteLine(user);
            }

            var names_1 = from user in users
                          select user.Name;

            Console.WriteLine();
            Console.WriteLine("Только имена пользователей: ");
            foreach (var name in names_1)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();
            Console.WriteLine("То же самое с использованием методов-расшиерений: ");
            var names_2 = users.Select(u => u.Name);

            foreach (var name in names_2)
            {
                Console.WriteLine(name);
            }
        }

        private static void CreateAnonymousTypeWIthLinq()
        {
            Console.WriteLine();
            Console.WriteLine("Возвращаем анонимный тип с помощью линка: ");
            List<User> users = new List<User>();
            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            Console.WriteLine();
            Console.WriteLine("Исходный массив: ");

            foreach (User user in users)
            {
                Console.WriteLine(user);
            }

            var items = from u in users
                        select new
                        {
                            FirstName = u.Name,
                            DateOfBirth = DateTime.Now.Year - u.Age
                        };

            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив: ");
            foreach (var n in items)
                Console.WriteLine($"{n.FirstName} - {n.DateOfBirth}");

            Console.WriteLine();
            Console.WriteLine("То же самое с использованием методов-расширений: ");
            var choices = users.Select(u => new { FirstName = u.Name, DateOfBirth = DateTime.Now.Year - u.Age });
            foreach (var choice in choices)
            {
                Console.WriteLine($"{choice.FirstName} - {choice.DateOfBirth}");
            }
        }

        static void Main(string[] args)
        {
            SelectNamesWithLinq();

            CreateAnonymousTypeWIthLinq();
        }
    }
}
