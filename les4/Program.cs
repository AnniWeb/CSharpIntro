using System;
using System.Linq;

namespace les4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1
            {
                string[,] testNames =
                {
                    {"Иванов", "Иван", "Иванович"},
                    {"Петров", "Петр", "Петрович"},
                    {"Сидоров", "Сидор", "Сидорович"},
                    {"Иванова", "Мария", "Ивановна"},
                };
                
                Console.WriteLine("Вывод полных имен:");
                for (int i = 0; i < testNames.GetLength(0); i++)
                {
                    Console.WriteLine((i+1) + ". " + Task1.GetFullName(testNames[i,0], testNames[i,1], testNames[i,2]));
                }
                Console.WriteLine();
            }
            
            // Задача 2
            {
                Console.WriteLine("Введите целые числа через пробел:");
                string numbers = Console.ReadLine();
                Console.WriteLine($"Сумма введенных чисел: {Task2.sumToSplit(numbers)}");
                Console.WriteLine();
            }
            
            // Задача 3
            {
                Console.Write("Введите номер месяца: ");
                int month = Int32.Parse(Console.ReadLine());
                var result = Task3.getSeasonNameByMonth(month, out string error);
                Console.WriteLine(result == null ? error : $"Сезон: {result}");
                Console.WriteLine();
            }
            
            // Задача 4
            {
                Console.Write("Введите целое число: ");
                int number = Int32.Parse(Console.ReadLine());
                int[] sequence = new int[0];
                
                int fibo = Task4.getFibonacci(number, ref sequence);
                Console.WriteLine($"Число Фибоначчи для {number}: {fibo}");
                Console.WriteLine($"Последовательность Фибоначчи для {number}: ");
                for (int i = 0; i < sequence.Length; i++)
                {
                    Console.Write($"{sequence[i]} ");
                }
                
            }
            
        }
    }
}