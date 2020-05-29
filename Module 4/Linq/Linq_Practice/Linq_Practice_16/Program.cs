using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Practice_16
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }


        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }

    class Program
    {

        private static void AllAnyContainsInLinq()
        {
            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };
            Console.WriteLine("Исходный массив: ");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();
            Console.WriteLine("Булева переменная: проверяет условие на всех элементах массива: ");
            Console.WriteLine("Все пользователи в массиве возрастом больше 20 лет:");
            bool age = users.All(i => i.Age > 20);
            Console.WriteLine(age);

            Console.WriteLine();
            Console.WriteLine("Имена всех пользователей начинается с буква Т: ");
            bool nameStartsWithT = users.All(i => i.Name.StartsWith("Т"));
            Console.WriteLine(nameStartsWithT) ;


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Булева переменная: проверяет, удовлетворяет ли условию хоть один элемент массива: ");
            bool age_2 = users.Any(i => i.Age <= 40);
            Console.WriteLine("Хотя бы один пользователь младше 40 лет: ");
            Console.WriteLine(age_2);

            bool nameStartsWithT_2 = users.Any(i => i.Name.StartsWith("Т"));
            Console.WriteLine("Имя хотя бы одного пользователя начинается с буквы Т: ");
            Console.WriteLine(nameStartsWithT);
        }

        static void Main(string[] args)
        {
            AllAnyContainsInLinq();
        }
    }
}
