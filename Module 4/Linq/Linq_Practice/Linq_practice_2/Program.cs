using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_practice_2
{
    class Program
    {
        /// <summary>
        /// Фильтрация массива с помощью linq-а
        /// </summary>
        private static void ChooseByLinq()
        {
            //Выводим все элементы исходного массива:
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 10 };
            Console.WriteLine("Выводим все элементы исходной коллекции: ");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            //Выполним фильтрацию с помощью linq-а
            IEnumerable<int> filtratedNumbers = from number in numbers
                                                where number % 2 == 0
                                                select number;
            Console.WriteLine();
            Console.WriteLine("Выводим только чётные числа, полученные с помощью фильтрации linq-ом");
            foreach (int number in filtratedNumbers)
            {
                Console.Write(number + " ");
            }
        }

        /// <summary>
        /// Фильтрация массива с помощью метода-расширения
        /// </summary>
        private static void ChooseByMethod()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 10 };
            IEnumerable<int> evens = numbers.Where(i => i % 2 == 0);
            Console.WriteLine();
            Console.WriteLine("Выводим информацию о фильтрованном массиве, полученном с помощью метода расширения:");
            foreach (int number in evens)
            {
                Console.Write(number + " ");
            }
        }

        static void Main(string[] args)
        {
            ChooseByLinq();

            ChooseByMethod();
        }
    }
}
