using System;

namespace lesson1
{
    class Program
    {
       static void Main(string[] args)
       {
           var name = String.Empty;
           Console.Write("Представтесь: ");
           name = Console.ReadLine();
           Console.WriteLine();
           Console.WriteLine("Привет, {0}, сегодня {1}", name, DateTime.Now.ToShortDateString());
           Console.ReadLine();
        }
    }
}