using System;

namespace les2_4
{
    class Program
    {
        enum DaysWeek
        {
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday = 0b_1000000,
        }

        static void Main(string[] args)
        {
            DaysWeek scheduleOfice1 = DaysWeek.Tuesday | DaysWeek.Wednesday | DaysWeek.Thursday | DaysWeek.Friday;
            DaysWeek scheduleOfice2 = DaysWeek.Monday | DaysWeek.Tuesday | DaysWeek.Wednesday | DaysWeek.Thursday 
                                      | DaysWeek.Friday | DaysWeek.Saturday | DaysWeek.Sunday;
            DaysWeek scheduleOfice3 = DaysWeek.Monday | DaysWeek.Wednesday | DaysWeek.Friday | DaysWeek.Sunday;
            
            Console.Write("Введите день недели[1-7]: ");
            int dayNumber = Int16.Parse(Console.ReadLine());

            if (dayNumber > 7 || dayNumber < 1)
            {
                Console.WriteLine("Введены не корректные данные");
                return;
            }
            
            DaysWeek dayMask = (DaysWeek) Math.Pow(2, dayNumber-1);
            
            if ((dayMask & scheduleOfice1) > 0)
            {
                Console.WriteLine("Офис 1 работает");
            }
            else
            {
                Console.WriteLine("Офис 1 не работает");
            }
            
            if ((dayMask & scheduleOfice2) > 0)
            {
                Console.WriteLine("Офис 2 работает");
            }
            else
            {
                Console.WriteLine("Офис 2 не работает");
            }
            
            if ((dayMask & scheduleOfice3) > 0)
            {
                Console.WriteLine("Офис 3 работает");
            }
            else
            {
                Console.WriteLine("Офис 3 не работает");
            }
        }
    }
}