using System;

namespace les3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] matrix;
            {
                
                Console.WriteLine("Введите желаемый размер матрицы:");
                Console.Write("Количество строк: ");
                int n = Int16.Parse(Console.ReadLine());
                Console.Write("Количество столбцов: ");
                int m = Int16.Parse(Console.ReadLine());
            
                matrix = new int[n,m];
                
                // Заполнение матрицы
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i,j] = rand.Next(0, 9);
                    }
                }
                
                Console.WriteLine("Вывод матрицы");
                // Вывод заполненой матрицы
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    Console.Write("\n");
                }
            }
            
            // Выполнение задания: вывод диагонали
            Console.WriteLine("Вывод главной диагонали");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    else
                    {
                        Console.Write($"x ");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("Вывод побочная диагонали");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix.GetLength(0) - 1 == i + j)
                    {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    else
                    {
                        Console.Write($"x ");
                    }
                }
                Console.Write("\n");
            }
            
            
        }
    }
}