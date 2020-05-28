using System;
using System.Linq;

namespace Linq_Practice_10
{
    class Program
    {

        private static void UnionMethods()
        {
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };
            Console.WriteLine("Множества до пересечения: ");

            Console.WriteLine("Множество soft: ");
            foreach (var company in soft)
            {
                Console.WriteLine(company);
            }

            Console.WriteLine();
            Console.WriteLine("Множество hard: ");
            foreach (var company in hard)
            {
                Console.WriteLine(company);
            }

            // разность последовательностей
            var result_1 = soft.Except(hard);

            Console.WriteLine();
            Console.WriteLine("Разность множеств:");
            foreach (string s in result_1)
                Console.WriteLine(s);

            var result_2 = soft.Intersect(hard);

            Console.WriteLine();
            Console.WriteLine("Пересечение множеств: ");
            foreach (var company in result_2)
            {
                Console.WriteLine(company);
            }

            var result_3 = soft.Union(hard);
            Console.WriteLine();
            Console.WriteLine("Объединение множеств без повторений:");
            foreach (var company in result_3)
            {
                Console.WriteLine(company);
            }

            var result_4 = soft.Concat(hard);
            Console.WriteLine();
            Console.WriteLine("Объединение множеств с повторениями: ");

            foreach (var company in result_4)
            {
                Console.WriteLine(company);
            }

            var result_5 = result_4.Distinct();

            Console.WriteLine();
            Console.WriteLine("Удаление повторений из прошлого результата: ");
            foreach (var company in result_5)
            {
                Console.WriteLine(company);
            }
        }

        static void Main(string[] args)
        {
            UnionMethods();
        }
    }
}
