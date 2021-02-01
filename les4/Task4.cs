using System;
using System.Linq;

namespace les4
{
    public class Task4
    {
        public static int getFibonacci(int number, ref int[] sequence, bool withNegative = false)
        {
            if (sequence.Length == 0)
            {
                if (number < 0)
                {
                    withNegative = true;
                    sequence = new int[-number*2 + 1];
                }
                else
                {
                    sequence = new int[number + 1];
                }
            }
            int id = withNegative ? sequence.Length/2 + number: number;
            
            // Начальные условия для последовательности Фибоначчи
            if (number == 0)
            {
                return number;
            }

            // Чтобы не искать уже найденное число
            if (sequence[id] != 0)
            {
                return sequence[id];
            }

            int newNumber;

            if (number == 1)
            {
                newNumber = number;
            }
            else if (withNegative && number < 0)
            {
                newNumber = getFibonacci(number + 2, ref sequence, withNegative) - getFibonacci(number + 1, ref sequence, withNegative);
                
                //Для заполнения положительной части последовательности 
                getFibonacci(-number, ref sequence, withNegative);
            }
            else {
                newNumber = getFibonacci(number - 1, ref sequence, withNegative) + getFibonacci(number - 2, ref sequence, withNegative);
            }
            
            
            sequence[id] = newNumber;
            
            return newNumber;
        }
    }
}