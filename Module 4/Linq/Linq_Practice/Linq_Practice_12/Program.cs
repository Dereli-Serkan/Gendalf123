using System;
using System.Linq;

namespace Linq_Practice_12
{
    class Program
    {

        private static void SkipInLinq()
        {
            Console.WriteLine("Исходный массив: ");
            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив, первые 3 элемента: ");
            var result_1 = numbers.Take(3);
            foreach (var number in result_1)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив, все элементы, кроме первых 3 элементов: ");
            var result_2 = numbers.Skip(3);
            foreach (var number in result_2)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив, сначала скипаем первые 4 элемента, затем берём первые 2:");
            var result_3 = numbers.Skip(4).Take(2);
            foreach (var number in result_3)
            {
                Console.Write(number + " ");
            }

            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Исходный массив команд: ");
            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }
            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив, берём все элементы, удовлетворяющие условию, пока в массиве не встретится элемент, не удовлетворяющий условию: ");
            var result_4 = teams.TakeWhile(i => i.StartsWith("Б"));
            foreach (var team in result_4)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine();
            Console.WriteLine("Фильтрованный массив, пропускаем все элементы, удовлетворяющие условию, пока в массиве не встретится элемент, не удовлетворяющий условию: ");
            var result_5 = teams.SkipWhile(i => i.StartsWith("Б"));
            foreach (var team in result_5)
            {
                Console.WriteLine(team);
            }
        }

        static void Main(string[] args)
        {
            SkipInLinq();
        }
    }
}
