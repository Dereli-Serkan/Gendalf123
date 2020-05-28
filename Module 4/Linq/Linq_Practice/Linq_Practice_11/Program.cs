using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Practice_11
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

        private static void AggregationMethods()
        {
            int[] numbers_1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Исходный массив: ");
            foreach (var number in numbers_1)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Результат применения агрегации разности: ");
            int query_1 = numbers_1.Aggregate((x, y) => x - y);
            Console.WriteLine(query_1);

            Console.WriteLine("Результат применения агрегации сложения: ");
            int query_2 = numbers_1.Aggregate((x, y) => x + y);
            Console.WriteLine(query_2);

            int [] numbers_2 = new int[] { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            Console.WriteLine();
            Console.WriteLine("Результат подсчета количества элементов после фильтрации линком: ");
            var count_2 = (from number in numbers_2 where number % 2 == 0 && number >= 10 select number).Count();
            Console.WriteLine(count_2);
            Console.WriteLine("Результат подсчета количества элементов после фильтрации методом-расширением: ");

            var count_3 = numbers_2.Count(i => i % 2 == 0 && i >= 10);
            Console.WriteLine(count_3);


            int[] numbers_3 = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            List<User> users_1 = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            Console.WriteLine();
            Console.WriteLine("Результат подсчёта суммы массива чисел: ");
            var sum_1 = numbers_3.Sum();
            Console.WriteLine(sum_1);

            Console.WriteLine("Результат подсчёта суммы свойства в сложном объекте");

            var sum_2 = users_1.Sum(user => user.Age);
            Console.WriteLine(sum_2);

            int[] numbers_4 = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            List<User> users_2 = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };
            Console.WriteLine();
            Console.WriteLine("Нахождение минимума :");
            Console.WriteLine("Числового массива: ");
            int min1 = numbers_4.Min();
            Console.WriteLine(min1);
            Console.WriteLine("Свойства сложного объекта: ");
            int min2 = users_2.Min(n => n.Age); // минимальный возраст
            Console.WriteLine(min2);

            Console.WriteLine();
            Console.WriteLine("Нахождение максимума: ");
            Console.WriteLine("Числового массива: ");
            int max1 = numbers_4.Max();
            Console.WriteLine(max1);
            Console.WriteLine("Свойства сложного объекта: ");
            int max2 = users_2.Max(n => n.Age); // максимальный возраст
            Console.WriteLine(max2);

            Console.WriteLine();
            Console.WriteLine("Нахождение среднего значения: ");
            Console.WriteLine("Числового массива: ");
            double avr1 = numbers_4.Average();
            Console.WriteLine(avr1);
            Console.WriteLine("Свойства сложного объекта");
            double avr2 = users_2.Average(n => n.Age); //средний возраст

        }

        static void Main(string[] args)
        {
            AggregationMethods();
        }
    }
}
