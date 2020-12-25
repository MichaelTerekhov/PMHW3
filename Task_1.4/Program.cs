using System;
using System.Collections;
using System.Collections.Generic;
namespace Task_1._4
{
    class Program
    {
        private static Stack<char> container = new Stack<char>();
        private static Stack<int> position = new Stack<int>();
        static bool Starts_With(char ent) => ent == '(' || ent == '{' || ent == '[' || ent == '<';
        static bool Ends_With(char ent) => ent == ')' || ent == '}' || ent == ']' || ent == '>';
        static bool Get_Pair(char start, char end) => end - start >= 1 && end - start <= 2;

        static void Checker(ref string checking)
        {
            for (var i = 0; i < checking.Length; i++)
            {
                if (Starts_With(checking[i]))
                {
                    container.Push(checking[i]);
                    position.Push(i);
                }
                else if (!(container.Count == 0) && Ends_With(checking[i]))
                {
                    if (Get_Pair(container.Peek(), checking[i]))
                    {
                        container.Pop();
                        position.Pop();
                        continue;
                    }
                    if (!Get_Pair(container.Peek(), checking[i]))
                    {
                        Console.WriteLine($"Oops, smth went wrong {checking[i]} havent starting bracket\n" +
                           $"'error on position {i}'");
                        container.Clear();
                        position.Clear();
                        return;
                    }
                }
               
               
            }
            if (!(container.Count == 0))
            {
                Console.WriteLine($"Oops, smth went wrong {container.Peek()} havent closing bracket\n" +
                        $"'error on position {position.Peek()}'");
                container.Clear();
                position.Clear();
                return;
            }
            if (container.Count == 0)
                Console.WriteLine("My friend, everything is fine with your expression,\n" +
                    "you did not miss the brackets!");        
        }

        static void Main(string[] args)
        {
            Hello();
            string input;
            while (true)
            {
                    Console.Write("Enter expression-> ");
                    input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                        continue;
                    break;
            }
            Checker(ref input);
            Console.ReadKey();
        }
        static void Hello()
        {
            Console.WriteLine("1.4 Hey, Bro!\n" +
                "You are given the opportunity to check your expression\n" +
                "for a sequence of brackets\t'<>, (), {}, []'\n\n" +
                "Correct sequences: (a+b); <(hello) + [world]>; [(a+b)*(a-b)]\n" +
                "Incorrect sequences: )a+b(; <hello]+[world>; [(a+b(*{a-b}]\n" +
                "(c)Michael Terekhov\n");
        }
    }
}

/*
 if (!Starts_With(checking[i]) && !Ends_With(checking[i])) continue;
                else if (Starts_With(checking[i])) container.Push(checking[i]);
                
                if (!(container.Count == 0) && Get_Pair(container.Peek(), checking[i]))
                {
                    container.Pop();
                }
                else if (container.Count != 0)
                {
                    if (i == checking.Length - 1)
                        Console.WriteLine($"Missing closing parenthesis for {checking[i]} on position {i},\n" +
                         $"because the correct parenthesis sequence is missing");
                }
                else if ((container.Count == 0) || (!(container.Count == 0) && !Get_Pair(container.Peek(), checking[i])))
                {
                    Console.WriteLine($"Missing open parenthesis for {checking[i]} on position {i},\n" +
                    $"because the correct parenthesis sequence is missing");
                    return;
                }
                else
                {
                    Console.WriteLine("Smth wrong!");
                    return;
                }
     
     */
