using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello();
            var list = new List<Player>
            {
                new Player{Age =29 ,FirstName= "Ivan", LastName="Ivanenko", Rank= PlayerRank.Captain },
                new Player{Age =19 ,FirstName= "Peter", LastName="Petrenko", Rank= PlayerRank.Private },
                new Player{Age =59 ,FirstName= "Ivan", LastName="Ivanov", Rank= PlayerRank.General },
                new Player{Age =52 ,FirstName= "Ivan", LastName="Snezko", Rank= PlayerRank.Lieutenant },
                new Player{Age =34 ,FirstName= "Alex", LastName="Zeshko", Rank= PlayerRank.Colonel },
                new Player{Age =29 ,FirstName= "Ivan", LastName="Ivanenko", Rank= PlayerRank.Captain },
                new Player{Age =19 ,FirstName= "Peter", LastName="Petrenko", Rank= PlayerRank.Private },
                new Player{Age =34 ,FirstName= "Vasiliy", LastName="Sokol", Rank= PlayerRank.Major },
                new Player{Age =31 ,FirstName= "Alex", LastName="Alexeenko", Rank= PlayerRank.Major }
            };
            Console.WriteLine("All list:\n");
            foreach (var m in list)
                Console.WriteLine(m);

            list = list.Distinct(new PlayerEqualityComparer()).ToList();
            Console.WriteLine("\nSorted by Age:\n");
            list.Sort(new SortByAge());
            foreach (var m in list)
                Console.WriteLine(m);
            

            Console.WriteLine("\nSorted by Rank:\n");
            list.Sort(new SortByRank());
            foreach (var m in list)
                Console.WriteLine(m);

            Console.WriteLine("\nSorted by Name:\n");
            list.Sort(new SortByName());
            foreach (var m in list)
                Console.WriteLine(m);

            Console.ReadKey();

        }
        static void Hello()
        {
            Console.WriteLine("1.2 Hey, Bro!\n" +
                "You are given the opportunity to see the statistics of the CounterStrike\n" +
                "tournament players in different views: sorting by name, age, rank.\n" +
                "(c)Michael Terekhov\n");
        }

    }
}
