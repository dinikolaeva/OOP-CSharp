using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            string command = Console.ReadLine();

            var queue = new Queue<string>(songs);

            while (queue.Count >= 0)
            {

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);

                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }

                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                command = Console.ReadLine();
            }

            
        }
    }
}
