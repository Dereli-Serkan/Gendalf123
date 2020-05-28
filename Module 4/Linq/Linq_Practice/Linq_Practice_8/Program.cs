using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_8
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

        private static void SortInLinq()
        {
            int[] array = new[] { 123, 10, 2345, 3, 1, 23, 3425, 10000 };
            Console.WriteLine("Исходный массив: ");
            foreach (var number in array)
            {
                Console.Write(number + " ");
            }

            var sortedArray = from number in array
                              orderby number
                              select number;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Отсортиванный c помощью линка массив: ");
            foreach (var number in sortedArray)
            {
                Console.Write(number + " ");
            }

            var sortedNumbers = array.OrderBy(i => i);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Отсортированный с помощью метода-расширения массив: ");
            foreach (var number in sortedNumbers)
            {
                Console.Write(number + " ");
            }
        }

        private static void ComplexSortInLinq()
        {
            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Пользователи до сортировки: ");
            foreach (User user in users)
            {
                Console.WriteLine(user);
            }

            var sortedUsers = from u in users
                              orderby u.Name
                              select u;

            Console.WriteLine();
            Console.WriteLine("Пользователи после сортировки по имени  c помощью линка: ");

            foreach (User u in sortedUsers)
                Console.WriteLine(u);

            Console.WriteLine();
            Console.WriteLine("Сортируем массив с помощью метода-расширения:");

            var sortedUsersMethod = users.OrderBy(user => user.Name);
            foreach (var user in sortedUsersMethod)
            {
                Console.WriteLine(user);
            }
            var sortedBackwords = from user in users
                                  orderby user.Name descending
                                  select user;


            Console.WriteLine();
            Console.WriteLine("Пользователи после сортировки по имени в обратном порядке: ");

            foreach (var user in sortedBackwords)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();
            Console.WriteLine("Пользователи после сортироваки по имени в обратном порядке с помощью метода-расширения");
            var sortedBackwordsMethod = users.OrderByDescending(user => user.Name);
            foreach (var user in sortedBackwordsMethod)
            {
                Console.WriteLine(user);
            }
        }


        static void Main(string[] args)
        {
            SortInLinq();

            ComplexSortInLinq();
        }
    }
}
