using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Practice_14
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

        private static void ManyRequestsInLinq()
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

            Console.WriteLine("Исходный массив до сортировки: ");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }

            var manyRequestsLinq = from phone in phones
                                   group phone by phone.Company into g
                                   select new
                                   {
                                       Name = g.Key,
                                       Count = g.Count(),
                                       Phones = from phone in g select phone
                                   };
            Console.WriteLine();
            Console.WriteLine("Фильтрованный с помощью множественных запросов массив: ");

            foreach (var group in manyRequestsLinq)
            {
                foreach (var phone in group.Phones)
                {
                    Console.WriteLine($"Group name: {group.Name}, Group Count: {group.Count}, Phone: {phone}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Аналогичная сортировка с помощью метода-расширения: ");
            var sortedPhones = phones.GroupBy(group => group.Company).Select(group => new
            {
                Name = group.Key,
                Count = group.Count(),
                Phones = group.Select(p => p)
            });

            foreach (var group in sortedPhones)
            {
                foreach (var phone in group.Phones)
                {
                    Console.WriteLine($"Group name: {group.Name}, Group Count: {group.Count}, Phone: {phone}");
                }
            }

        }

        static void Main(string[] args)
        {
            ManyRequestsInLinq();
        }
    }
}
