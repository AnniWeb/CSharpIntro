using System;
using System.Linq;

namespace les3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine();
            for (int i = str.Length-1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
            
            Console.WriteLine(new String(str.ToCharArray().Reverse().ToArray()));
        }
    }
}