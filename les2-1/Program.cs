using System;

namespace les2_1
{
    class Program
    {
        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December,
        }
        static void Main(string[] args)
        {
            double minTemp, maxTemp;
            Month curMonth;
            
            Console.Write("Введите минимальную температуру за сутки: ");
            minTemp = double.Parse(Console.ReadLine());
            Console.Write("Введите максимальную температуру за сутки: ");
            maxTemp = double.Parse(Console.ReadLine());

            double avrTemp = (minTemp + maxTemp) / 2;
            Console.WriteLine($"Среднесуточная температура: {avrTemp}");
            
            Console.Write("Введите номер месяца [1-12]: ");
            curMonth = (Month) Int16.Parse(Console.ReadLine());

            if ((int) curMonth > 12 || (int) curMonth < 1)
            {
                Console.WriteLine($"Введено некорректное значение месяца: {curMonth}");
                return;
            }
            
            Console.WriteLine(curMonth);
            // switch (curMonth)
            // {
            //     case Month.January:
            //         Console.WriteLine("Январь");
            //         break;
            //     case Month.February:
            //         Console.WriteLine("Февраль");
            //         break;
            //     case Month.March:
            //         Console.WriteLine("Март");
            //         break;
            //     case Month.April:
            //         Console.WriteLine("Апрель");
            //         break;
            //     case Month.May:
            //         Console.WriteLine("Май");
            //         break;
            //     case Month.June:
            //         Console.WriteLine("Июнь");
            //         break;
            //     case Month.July:
            //         Console.WriteLine("Июль");
            //         break;
            //     case Month.August:
            //         Console.WriteLine("Август");
            //         break;
            //     case Month.September:
            //         Console.WriteLine("Сентябрь");
            //         break;
            //     case Month.October:
            //         Console.WriteLine("Октябрь");
            //         break;
            //     case Month.November:
            //         Console.WriteLine("Ноябрь");
            //         break;
            //     case Month.December:
            //         Console.WriteLine("Декабрь");
            //         break;
            //     default:
            //         Console.WriteLine($"Введено некорректное значение: {curMonth}");
            //         break;
            // }

            if (avrTemp > 0 && (curMonth == Month.December || curMonth == Month.January || curMonth == Month.February))
            {
                Console.WriteLine("Дождливая зима");
            }
        }
    }
}