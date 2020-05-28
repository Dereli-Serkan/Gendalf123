using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_7
{
    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        /// <summary>
        /// Множественные источники в линке
        /// </summary>
        private static void MultipleSourcesInLinq()
        {
            List<User> users = new List<User>()
            {
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Tom", Age = 33 }
            };

            List<Phone> phones = new List<Phone>()
            {
             new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple"},
            };

            var people = from user in users
                         from phone in phones
                         select new { Name = user.Name, Phone = phone.Name };

            foreach (var p in people)
                Console.WriteLine($"{p.Name} - {p.Phone}");
        }

        static void Main(string[] args)
        {
            MultipleSourcesInLinq();
        }
    }
}
