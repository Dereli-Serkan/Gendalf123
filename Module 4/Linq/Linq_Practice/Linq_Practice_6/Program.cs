using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_6
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
        /// <summary>
        /// Создаем переменные в линке
        /// </summary>
        private static void CreateVariableInLink()
        {
            List<User> users = new List<User>()
            {
             new User { Name = "Sam", Age = 43 },
             new User { Name = "Tom", Age = 33 }
            };

            Console.WriteLine("Массив до фильтрации: ");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            var people = from user in users
                         let name = "Mr." + user.Name
                         select new { Name = name, Age = user.Age };

            Console.WriteLine("Массив после фильтрации: ");
            foreach (var person in people)
            {
                Console.WriteLine($"Name: " + person.Name + " Age: " + person.Age);
            }

        }

        static void Main(string[] args)
        {
            CreateVariableInLink();
        }
    }
}
