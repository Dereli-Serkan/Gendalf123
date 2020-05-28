using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_9
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

        private static void ManyCriterionChoiceLinq()
        {
            List<User> users = new List<User>()
            {
             new User { Name = "Tom", Age = 33 },
             new User { Name = "Bob", Age = 30 },
             new User { Name = "Tom", Age = 21 },
             new User { Name = "Sam", Age = 43 }
            };
            Console.WriteLine("Массив пользователей до сортировки: ");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            var result = from user in users
                         orderby user.Name, user.Age
                         select user;
            Console.WriteLine();
            Console.WriteLine("Массив пользователей после множественной сортировки по имени и возрасту c помощью линка: ");
            foreach (User u in result)
                Console.WriteLine(u);

            Console.WriteLine();
            Console.WriteLine("Массив пользователей после множественной сортировки по имени и возрасту с помощью метода-расширения: ");

            var sortedUsersMethod = users.OrderBy(user => user.Name).ThenBy(user => user.Age);

            foreach (var user in sortedUsersMethod)
            {
                Console.WriteLine(user);
            }
        }

        static void Main(string[] args)
        {
            ManyCriterionChoiceLinq();
        }
    }
}
