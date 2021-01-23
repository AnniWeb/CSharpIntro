using System;

namespace les3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[,] contacts = new string[5,2];
            
            // Заполнение
            for (int i = 0; i < contacts.GetLength(0); i++)
            {
                contacts[i,0] = $"Контакт {i+1}";
                contacts[i,1] = String.Format($"{rand.Next(900_000, 999_999):+7 (###) ###}") 
                                + String.Format($"{rand.Next(1000, 9999):-##-##}");
            }
            
            // Вывод
            for (int i = 0; i < contacts.GetLength(0); i++)
            {
                Console.WriteLine($"{contacts[i,0]}: {contacts[i,1]}");
            }
        }
    }
}