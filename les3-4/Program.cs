using System;

namespace les3_4
{
    class Program
    {
        // Проверка возможности установки корабля
        static bool isFree(char[,] desk, int size, bool isHorz, int x, int y)
        {
            if (isHorz)
            {
                for (int i = Math.Max(0, x - 1); i <= Math.Min(9, x + 1); ++i)
                {
                    for (int j = Math.Max(0, y - 1); j <= Math.Min(9, y + size); ++j)
                    {
                        if (desk[i, j] == 'X')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                for (int i = Math.Max(0, x - 1); i <= Math.Min(9, x + size); ++i)
                {
                    for (int j = Math.Max(0, y - 1); j <= Math.Min(9, y + 1); ++j)
                    {
                        if (desk[i, j] == 'X')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        // Учтановка корабля
        static char[,] setShip(char[,] desk, int size)
        {
            Random rand = new Random();
            bool isHorz = rand.Next(0, 100)%2 == 1; // чтобы рандом корректнее работал взяла не 2 значения, а 100
            int x = 0;
            int y = 0;

            // Определение начальных координат коробля
            do
            {
                do
                {
                    x = rand.Next(0, 9);
                } while (!isHorz && x > 10 - size);
                do
                {
                    y = rand.Next(0, 9);
                } while (isHorz && y > 10 - size);
            } while (!isFree(desk, size, isHorz, x, y));

            // Установка корабля
            if (isHorz)
            {
                for (int j = y; j < y + size; ++j)
                {
                    desk[x,j] = 'X';
                }
            }
            else
            {
                for(int i = x; i < x + size; ++i)
                {
                    desk[i,y] = 'X';
                }    
            }
            
            return desk;
        }

        static void Main(string[] args)
        {
            char[,] desk = new char[10,10];
            
            // Заполнение доски пустотой
            for (int i = 0; i < desk.GetLength(0); i++)
            {
                for (int j = 0; j < desk.GetLength(1); j++)
                {
                    desk[i, j] = 'O';
                }
            }
            
            // Установка кораблей
            for(int i = 0; i < 1; ++i)
            {
                desk = setShip(desk, 4);
            }
 
            for(int i = 0; i < 2; ++i)
            {
                desk = setShip(desk, 3);
            }
 
            for(int i = 0; i < 3; ++i)
            {
                desk = setShip(desk, 2);
            }
 
            for(int i = 0; i < 4; ++i)
            {
                desk = setShip(desk, 1);
            }
            
            // Вывод кораблей
            for (int i = 0; i < desk.GetLength(0); i++)
            {
                for (int j = 0; j < desk.GetLength(1); j++)
                {
                    Console.Write($"{desk[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}