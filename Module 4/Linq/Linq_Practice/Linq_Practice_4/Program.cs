using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_4
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

        private static void ComplexFiltration()
        {
            List<User> users = new List<User>
                {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
                };

            Console.WriteLine("Массив пользователей по фильтрации:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            var selectedUsers = from user in users
                                from lang in user.Languages
                                where user.Age > 20
                                where lang == "испанский"
                                select user;
            Console.WriteLine();
            Console.WriteLine("Массив пользователей после фильтрации:");
            foreach (var user in selectedUsers)
            {
                Console.WriteLine(user);
            }
        }

        private static void ComplexFiltrationWithMethod()
        {
            Console.WriteLine();
            Console.WriteLine("Фильтруем массив с помощью метода-расширения:");

            List<User> users = new List<User>
                {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
                };

            Console.WriteLine();
            Console.WriteLine("Исходный массив: ");

            foreach (User user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив: ");
            IEnumerable<User> spanish = users.SelectMany(u => u.Languages, (user, language) => new { User = user, Language = language }).Where(u => u.Language == "испанский" && u.User.Age > 20)
                          .Select(u => u.User);
            foreach (User user in spanish)
            {
                Console.WriteLine(user);
            }
        }

        static void Main(string[] args)
        {
            ComplexFiltration();

            ComplexFiltrationWithMethod();
        }
    }
}
