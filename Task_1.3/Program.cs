using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Region, RegionSettings> dic;
            int N;
            Hello();
          
                while (true)
                {
                    Console.Write("Try to input capacity of your dictionary -> ");
                    if (!int.TryParse(Console.ReadLine(), out N)) continue;
                    else break;
                }
            dic = new Dictionary<Region, RegionSettings>(N);
            int i = 0;
            while (i < N)
            {
                Console.WriteLine("Please write Region Key:\n");

                string Brand;
                Console.Write("Please enter Brand -> ");
                Brand = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(Brand))
                    continue;

                string Country;
                Console.Write("Please enter Country -> ");
                Country = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(Country))
                    continue;

                Console.WriteLine("Please write Region Website:\n");

                string Web;
                Console.Write("Please enter Website -> ");
                Web = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(Web))
                    continue;

                var region = new Region(Brand.ToUpper(), Country.ToUpper());
                if (!dic.ContainsKey(region))
                {
                    var val = new RegionSettings(Web);
                    dic.Add(region, val);
                    i++;
                    continue;
                }
                else
                {
                    Console.WriteLine("\nBe careful, you are entering duplicate key!");
                    continue;
                }
            }
             foreach(var m in dic)
                Console.WriteLine(m.Key+"="+m.Value);
            Console.ReadKey();
        }

        static void Hello()
        {
            Console.WriteLine("1.3 Hey, Bro!\n" +
                "You are given a unique opportunity to fill in the regional dictionary\n" +
                "of websites with the ability to view it\n" +
                "(c)Michael Terekhov\n");
        }
    }
}
