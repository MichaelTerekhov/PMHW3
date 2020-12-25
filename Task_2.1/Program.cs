using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_2._1
{
    class Program
    {
        static int Main(string[] args)
        {
            List<Goods> goods = new List<Goods>();
            List<Tags> tag = new List<Tags>();
            List<Inventory> invent = new List<Inventory>();
            try
            {
                var inp = File.ReadAllLines("invent.csv");
                invent.AddRange(inp.ToList()
                    .Skip(1)
                    .Select(x =>
                    {
                        var val = x.Split(new char[] { ';' });
                        var gd = new Inventory(val[0], val[1], Convert.ToInt32(val[2]));
                        return gd;
                    }).ToList());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File wasnt found!");
                return -1;
            }

            try
            {
                var inp = File.ReadAllLines("tags.csv");
                tag.AddRange(inp.ToList()
                    .Skip(1)
                    .Select(x =>
                    {
                        var val = x.Split(new char[] { ';' });
                        var gd = new Tags(val[0], val[1]);
                        return gd;
                    }).ToList());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File wasnt found!");
                return -1;
            }
            try
            {
                var inp = File.ReadAllLines("prod.csv");
                goods.AddRange(inp.ToList()
                    .Skip(1)
                    .Select(x=>
                    {
                        var val = x.Split(new char[] { ';' });
                        Goods gd = new Goods(val[0], val[1], val[2], Convert.ToDecimal(val[3]));
                        gd.tags = tag.Where(m => m.GoodsId == val[0]).ToList();
                        return gd;
                    }).ToList());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File wasnt found!");
                return -1;
            }

            foreach(var m in goods)
                Console.WriteLine(m);
            Hello();
            Menu(goods,invent);
            Console.ReadKey();
            return 0;
        }
        static void Hello()
        {
            Console.WriteLine("2.1 Hey, Bro!\n" +
                "Welcome to the manager of goods control in your warehouses\n\n" +
                "Here is a menu for working with this manager:\n");
        }
        static void Menu(List<Goods> goods,List<Inventory> invent)
        {
            Console.WriteLine("1.\tEXIT\n\n" +
                "2.\tGOODS\n\n" +
                "3.\tLEFTOVERS\n\n" +
                "Just write number of list paragraph\tEx: 2");
            while (true)
            {
                Console.WriteLine("\nMain Menu");
                Console.Write("\nSelect-> ");
                var MainChoo = Console.ReadLine();
                if (String.IsNullOrEmpty(MainChoo))
                    continue;
                if (!int.TryParse(MainChoo, out int UpperLevel))
                    continue;
                if (UpperLevel == 1)
                {
                    Console.WriteLine("See you next time!");
                    return;
                }
                if (UpperLevel == 2)
                {
                    GoodsLevel(goods);
                    continue;
                }
                if (UpperLevel == 3)
                {
                    StorageLevel(invent);
                    continue;
                }
                Console.WriteLine("\nWrong input!Reselect please!");
            }
        }

        private static void StorageLevel(List<Inventory> invent)
        {
            Console.WriteLine("Storage manager");
            Console.WriteLine("1.\tRETURN TO MENU\n\n" +
            "2.\tMISSING ITEMS\n\n" +
            "3.\tALL GOODS THAT IN STOCK FOR RISING\n\n" +
            "4.\tALL GOODS THAT IN STOCK FOR SALVATION\n\n" +
            "Just write number of list paragraph\tEx: 2");
            while (true)
            {
                Console.WriteLine("\nStorage Menu");
                Console.Write("\nSelect-> ");
                var StorageChoo = Console.ReadLine();
                if (String.IsNullOrEmpty(StorageChoo))
                    continue;
                if (!int.TryParse(StorageChoo, out int StorageLevel))
                    continue;
                if (StorageLevel == 1)
                {
                    return;
                }
                if (StorageLevel == 2)
                {
                    var selected = invent.Where(x => x.Count == 0).ToList();
                    selected = selected.OrderBy(x => x.Count).ToList();
                    foreach(var m in selected)
                        Console.WriteLine(m);
                    continue;
                }
                if (StorageLevel == 3)
                {
                    invent = invent.OrderBy(u => u.Count).ToList();
                    foreach (var m in invent)
                        Console.WriteLine(m);
                    Console.WriteLine($"Total number of goods {invent.Select(x=>x.Count).Sum()}");
                    continue;
                }
                if (StorageLevel == 4)
                {
                    invent = invent.OrderByDescending(u => u.Count).ToList();
                    foreach (var m in invent)
                        Console.WriteLine(m);
                    Console.WriteLine($"Total number of goods {invent.Select(x => x.Count).Sum()}");
                    continue;
                }
                if (StorageLevel == 5)
                {
                    FindGoodsOnStorage(invent);
                    continue;
                }
                Console.WriteLine("\nWrong input!Reselect please!");
            }

        }

        private static void FindGoodsOnStorage(List<Inventory> invent)
        {
            Console.WriteLine("Please write GoodsId to find particular good!");
            while (true)
            {
                Console.WriteLine("\nStorage Menu");
                Console.Write("\nSelect-> ");
                var StorageChoo = Console.ReadLine();
                if (String.IsNullOrEmpty(StorageChoo))
                    continue;
                var selected = invent.Where(x => x.GoodsId.Equals(StorageChoo, StringComparison.OrdinalIgnoreCase)).ToList();
                if (selected.Count == 0)
                {
                    Console.WriteLine("Search failed, because no match results!");
                }
                else
                {
                    selected =selected.OrderByDescending(u => u.Count).ToList();
                    foreach (var m in selected)
                        Console.WriteLine(m);
                    break;
                }
            }
        }

        static void GoodsLevel(List<Goods> goods)
        {
            Console.WriteLine("Goods manager\n");
                Console.WriteLine("1.\tRETURN TO MENU\n\n" +
                "2.\tFIND GOODS\n\n" +
                "3.\tALL GOODS FOR RISING COST\n\n" +
                "4.\tALL GOODS FOR SALVATION COST\n\n" +
                "Just write number of list paragraph\tEx: 2");
            while (true)
            {
                Console.WriteLine("\nGoods Menu");
                Console.Write("\nSelect-> ");
                var GoodsChoo = Console.ReadLine();
                if (String.IsNullOrEmpty(GoodsChoo))
                    continue;
                if (!int.TryParse(GoodsChoo, out int GoodsLevel))
                    continue;
                if (GoodsLevel == 1)
                {
                    return;
                }
                if (GoodsLevel == 2)
                {
                    FindMe(goods);
                    continue;
                }
                if (GoodsLevel == 3)
                {
                    goods = goods.OrderBy(u => u.Cost).ToList();
                    foreach (var m in goods)
                        Console.WriteLine(m);
                    continue;
                }
                if (GoodsLevel == 4)
                {
                    goods = goods.OrderByDescending(u => u.Cost).ToList();
                    foreach(var m in goods)
                        Console.WriteLine(m);
                    continue;
                }
                Console.WriteLine("\nWrong input!Reselect please!");
            }
        }

        private static void FindMe(List<Goods> goods)
        {
            Console.WriteLine("Please write KEY word to find particular good!");
            while (true)
            {
                Console.WriteLine("\nGoods Menu");
                Console.Write("\nSelect-> ");
                var GoodsChoo = Console.ReadLine();
                if (String.IsNullOrEmpty(GoodsChoo))
                    continue;
                var selected = goods.Where(x=> x.Id.Equals(GoodsChoo, StringComparison.OrdinalIgnoreCase) || x.Brand.Equals(GoodsChoo, StringComparison.OrdinalIgnoreCase) || x.Model.Equals(GoodsChoo, StringComparison.OrdinalIgnoreCase) || x.tags.Any(t=> t.TagsValue.Equals(GoodsChoo, StringComparison.OrdinalIgnoreCase))).Distinct(new GoodsEqualityComparer()).ToList();
                if (selected.Count == 0)
                {
                    Console.WriteLine("Search failed, because no match results!");
                }
                else
                {
                    foreach(var m in selected)
                        Console.WriteLine(m);
                    break;
                }
            }
        }
    }
}
