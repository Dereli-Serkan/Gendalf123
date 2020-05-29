using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Practice_15
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Team: {Team}";
        }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Country: {Country}";
        }
    }

    class Program
    {

        private static void JoinInLinq()
        {
            Console.WriteLine("Метод Join");

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };

            Console.WriteLine("Исходный массив команд: ");
            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }

            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };
            Console.WriteLine();
            Console.WriteLine("Исходный массив игроков: ");
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }

            var result = from player in players
                         join team in teams on player.Team equals team.Name
                         select new
                         {
                             TeamName = team.Name,
                             PlayerName = player.Name,
                             Country = team.Country
                         };
            Console.WriteLine($"Result count {result.Count()}");
            Console.WriteLine();
            Console.WriteLine("Объединённые по имени массивы. Линк: ");
            foreach (var player in result)
            {
                Console.WriteLine($"Team Name: {player.TeamName}, Player Name: {player.PlayerName}, Country: {player.Country}");
            }

            Console.WriteLine();
            Console.WriteLine("То же объединение с помощью методов-расширений: ");
            var result_2 = teams.GroupJoin(players, team => team.Name, player => player.Team, (team, player) => new
            {
                TeamName = team.Name,
                PlayerName = player.Select(pl => pl.Name),
                Country = team.Country
            }) ;

            foreach (var player in result_2)
            {
                Console.WriteLine($"Team Name: {player.TeamName}, Country: {player.Country}");
            }
        }

        private static void ZipInLinq()
        {
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" },
                new Team { Name = "Ювентус", Country ="Италия" }
            };
            Console.WriteLine();
            Console.WriteLine("Метод Zip");
            Console.WriteLine();
            Console.WriteLine("Исходный массив команд: ");
            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }

            List<Player> players = new List<Player>()
            {
                new Player {Name="Роббен", Team="Бавария"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Буффон", Team="Ювентус"}
            };

            Console.WriteLine();
            Console.WriteLine("Исходный массив игроков: ");
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }

            var zipResult = teams.Zip(players, (team, player) => new
            {
                Name = player.Name,
                Team = team.Name,
                Country = team.Country
            });
            Console.WriteLine();
            Console.WriteLine("Результат использования метода Zip: ");
            foreach (var player in zipResult)
            {
                Console.WriteLine($"Name: {player.Name}, Team: {player.Team}, Country: {player.Country}");
            }
        }


        static void Main(string[] args)
        {
            JoinInLinq();

            ZipInLinq();
        }
    }
}
