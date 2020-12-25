using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello();
            Rules();
            string input;
            string[] arrayInput;
            List<int> array = new List<int> { };
            while (true)
            {
              Console.Write("Enter array-> ");
              input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                    continue;
                arrayInput = input.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries);
                if (!arrayInput.All(x => int.TryParse(x, out _)))
                    continue;
                break;
            }
            array = arrayInput.Select(x => x.Trim()).Select(x => int.Parse(x)).ToList();
            Stats(array);

            Console.ReadKey();
        }


        static void Hello()
        {
            Console.WriteLine("1.1 Hey Bro!\n" +
                "You are given the opportunity to find out the specific statistics\n" +
                "for your entered array\n" +
                "(c)Michael Terekhov\n");
        }
        static void Rules()
        {
            Console.WriteLine("You just need to enter array with ',' separator!\n\n" +
                "Correct example:\t|1,2,-1,32,4|\t |23,24,1,34,,,|\n\n" +
                "Incorrect example:\t |10,20  23, 231,23|");
        }
        static void Stats(List<int> array)
        {
            Console.WriteLine("Lets see statistic!\n");
            Console.Write($"Our array is ");
            foreach (var m in array)
                Console.Write($"{m}\t");
            Console.WriteLine();
            Console.WriteLine($"Min number in array is {array.Min()}"); 
            Console.WriteLine($"Min number in array is {array.Max()}");
            Console.WriteLine($"Sum of all elements in array is {array.Sum()}");
            Console.WriteLine($"Ariphmetic average of all elements in array is {array.Average()}");
            Console.WriteLine($"Standard deviation is {Math.Sqrt((array.Select(x => Math.Pow(x - array.Average(), 2)).Sum())/array.Count)}");
            var sorted = array.OrderBy(x=>x).Distinct();
            Console.Write("Our sorted array: ");
            foreach(var m in  sorted)
                Console.Write($"{m}\t");
            Console.WriteLine();
        }
    }
}
