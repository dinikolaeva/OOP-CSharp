using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            Stack<string> newText = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string commands = Console.ReadLine();

                if (commands.StartsWith('1'))
                {
                    string text = commands.Substring(2);
                    sb.Append(text);
                    newText.Push(sb.ToString());
                }
                else if (commands.StartsWith('2'))
                {
                    int countOfChars = int.Parse(commands.Substring(2));
                    sb = sb.Remove(sb.Length - countOfChars, countOfChars);
                    newText.Push(sb.ToString());
                }
                else if (commands.StartsWith('3'))
                {
                    int index = int.Parse(commands.Substring(2));
                    Console.WriteLine(sb[index - 1]);
                }
                else if (commands.StartsWith('4'))
                {
                    if (newText.Count > 1)
                    {
                        newText.Pop();
                        sb = sb.Clear();
                        sb = sb.Append(newText.Peek());
                    }
                    else
                    {
                        newText.Pop();
                        sb = sb.Clear();
                    }
                }
            }
        }
    }
}
