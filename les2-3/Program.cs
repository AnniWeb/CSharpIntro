using System;
using Microsoft.VisualBasic;

namespace les2_3
{
    class Program
    {
        static void printStringAlignCenter(string text)
        {
            int x, y;
            int width = 50; // Console.WindowWidth
            x = (width / 2) - (text.Length / 2);
            y = Console.CursorTop;
            
            Console.SetCursorPosition(x, y); 
            Console.WriteLine(text);
        }
        
        static void Main(string[] args)
        {
            String kkm = new String('0', 8);
            String inn = new String('0', 12);
            String company = "ООО 'Суперчек.ru'";
            String cashier = "Иванов";
            string bill = "4201";
            DateTime date = DateTime.Now;
            String[] products =
            {
                "Кирпич М-150",
                "Цемент ПЦ-400 д20 (мешках)",
                "Щебень фракции 20х40 т.",
                "Гвозди жидкие / 310мл",
            };
            int[] quantity =
            {
                800,
                1,
                5,
                4,
            };
            double[] price =
            {
                10.22,
                5400,
                480,
                163,
            };

            // Console.BackgroundColor = ConsoleColor.White;
            // Console.ForegroundColor = ConsoleColor.Black;
            
            printStringAlignCenter(company);
            printStringAlignCenter($"Чек №{bill}");
            printStringAlignCenter($"Кассир: {cashier}");

            double sum = 0;
            for (int i = 0; i < products.Length; i++)
            {
                double productPrice = quantity[i] * price[i];
                sum += productPrice;
                Console.WriteLine($"{i+1, 2}. {products[i]} {quantity[i]} X {price[i]:F2}");
                Console.WriteLine($"    Стоимость: {productPrice, 35:F2}");
            }
            Console.WriteLine(new String('=', 50));
            Console.WriteLine($"Всего: {sum, 43:F2}");
            Console.WriteLine($"ККМ {kkm} ИНН {inn} {'№' + bill, 20}");
            Console.WriteLine($"{date.ToString("dd.MM.yy hh:mm")} {cashier, 35}");
            Console.WriteLine($"Итог: {sum, 44:F2}");
        }
    }
}