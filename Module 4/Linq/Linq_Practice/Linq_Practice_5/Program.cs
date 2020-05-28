using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var names = from user in users
                        select user.Name;

            Console.WriteLine();
            Console.WriteLine("Только имена пользователей: ");
            foreach (var name in names)
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
        }

        static void Main(string[] args)
        {
            SelectNamesWithLinq();

            CreateAnonymousTypeWIthLinq();
        }
    }
}
