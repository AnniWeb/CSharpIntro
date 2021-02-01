using System;

namespace les4
{
    public class Task2
    {
        public static int sumToSplit(string stringNumbers)
        {
            int sum = 0;

            string[] numbers = stringNumbers.Split(" ");

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += Int32.Parse(numbers[i]);
            }
            
            return sum;
        }
    }
}