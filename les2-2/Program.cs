using System;

namespace les2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEven;
            
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());

            isEven = number % 2 == 0;
            // isEven = (number & 1) == 0;

            if (isEven)
            {
                Console.WriteLine($"Число {number}: четное");
            }
            else
            {
                Console.WriteLine($"Число {number}: нечетное");
            }
        }
    }
}