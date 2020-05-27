using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Practice
{
    class Program
    {

        private static void NoLinq1()
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = new List<string>();
            foreach (string s in teams)
            {
                if (s.ToUpper().StartsWith("Б"))
                    selectedTeams.Add(s);
            }
            selectedTeams.Sort();

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
        }

        private static void WithLinq1()
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = from t in teams // определяем каждый объект из teams как t
                                where t.ToUpper().StartsWith("Б") //фильтрация по критерию
                                orderby t  // упорядочиваем по возрастанию
                                select t; // выбираем объект

            foreach (string s in selectedTeams)
                Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Без линка код больше");
            NoLinq1();
            Console.WriteLine("C линком функционал тот же, но кода меньше");
            WithLinq1();

        }
    }
}
