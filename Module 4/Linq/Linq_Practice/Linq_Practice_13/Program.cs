using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice_13
{
    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Company: {Company}";
        }
    }

    class Program
    {

        private static void GroupInLink()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };

            Console.WriteLine("Исходный массив телефонов: ");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

            var phoneGroups = from phone in phones
                              group phone by phone.Company;

            Console.WriteLine();
            Console.WriteLine("Массив, сгруппированный по имени компании: ");
            var sortedGroups = from groupes in phoneGroups
                               orderby groupes.Count()
                               select groupes;
            foreach (var group in sortedGroups)
            {
                foreach (var phone in group)
                {
                    Console.WriteLine(phone);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Аналогичное сортирование с помощью методов-расширений: ");
            var sortedGroup = phones.GroupBy(i => i.Company).OrderBy(i => i.Count());
            foreach (var group in sortedGroup)
            {
                foreach (var phone in group)
                {
                    Console.WriteLine(phone);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Создание нового объекта с помощью линка: ");
            var sortedGroup_2 = from phone in phones
                                group phone by phone.Company into g
                                select new { Name = g.Key, Count = g.Count() };
            foreach (var group in sortedGroup_2)
            {
                Console.WriteLine($"Group name: {group.Name}, Group count: {group.Count}");
            }

            Console.WriteLine();
            Console.WriteLine("Та же самая сортировка с применением методов-расширений: ");
            var sortedGroup_3 = phones.GroupBy(group => group.Company).Select(group => new { Name = group.Key, Count = group.Count() });

            foreach (var group in sortedGroup_3)
            {
                Console.WriteLine($"Group name: {group.Name}, Group count: {group.Count}");
            }
        }

        static void Main(string[] args)
        {
            GroupInLink();
        }
    }
}
