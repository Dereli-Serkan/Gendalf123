using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_3
{
    /// <summary>
    /// Класс пользователь
    /// </summary>
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }

        private string ReturnLanguages()
        {
            string result = "";
            for (int i = 0; i < Languages.Count; i++)
            {
                if (i == Languages.Count - 1) result += Languages[i] + ".";
                else { result += Languages[i] + ", "; }
            }
            return result;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Languages: {ReturnLanguages()}";
        }
    }

    class Program
    {
        /// <summary>
        /// Фильтрация сложных объектов
        /// </summary>
        private static void ChooseComplexObjects()
        {
            List<User> users = new List<User>
            {
            new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
            new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
            new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
            new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var selectedFeatures = from user in users
                                   where user.Age > 20
                                   select user;
            Console.WriteLine("Выводим информацию о пользователях, чей возраст больше 20 лет");
            Console.WriteLine("Сортировали с помощью linq-запроса");
            foreach (User user in selectedFeatures)
            {
                Console.WriteLine(user);
            }
        }

        private static void ChooseWithMethod()
        {
            List<User> users = new List<User>
            {
            new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
            new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
            new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
            new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            Console.WriteLine();
            Console.WriteLine("Отфильтровано с помощью метода-расширения:");
            Console.WriteLine("Отсортировано с помощью метода OrderBy");
            IEnumerable<User> adults = users.Where(user => user.Age > 20).OrderBy(user => user.Age);
            foreach (var user in adults)
            {
                Console.WriteLine(user);
            }
        }

        static void Main(string[] args)
        {
            ChooseComplexObjects();

            ChooseWithMethod();
        }
    }
}
