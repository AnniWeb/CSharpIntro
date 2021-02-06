using System;
using System.IO;

namespace les5
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string randomString, fileName = "random.txt";
                Console.WriteLine("Введите текст:");
                randomString = Console.ReadLine();
                
                File.WriteAllText(fileName, randomString);
            }
            
            {
                string fileName = "startup.txt";
                
                File.AppendAllText(fileName, DateTime.Now.ToString("F") + Environment.NewLine);
            }
            
            {
                string [] randomNumbers;
                string fileName = "random_numbers.bin";
                Console.WriteLine("Введите числа от 0 до 255 через пробел");
                randomNumbers = Console.ReadLine().Split(" ");
                byte[] num = new byte[randomNumbers.Length];
                for (int i = 0; i < randomNumbers.Length; i++)
                {
                    num[i] = Byte.Parse(randomNumbers[i]);
                }
                File.WriteAllBytes(fileName, num);
            }

            {
                string fileName = "tree.txt";
                string[] tree = new string[0];
                Task4.GetTreeRecursive(Directory.GetCurrentDirectory(), ref tree);
                File.WriteAllLines(fileName, tree);
                
                fileName = "tree1.txt";
                tree = new string[0];
                Task4.GetTreeWithoutRecursive(Directory.GetCurrentDirectory(), ref tree);
                File.WriteAllLines(fileName, tree);
            }

            {
                // Тестовое наполнение
                ITaskRepository repository;
                Task[] testTasks =
                {
                    new Task("Сделать ДЗ1", true),
                    new Task("Сделать ДЗ2", true),
                    new Task("Сделать ДЗ3", true),
                    new Task("Сделать ДЗ4", true),
                    new Task("Сделать ДЗ5", false),
                };
                
                repository = new JsonTaskRepository();
                repository.saveTasks(testTasks);
                
                // repository = new XmlTaskRepository();
                // repository.saveTasks(testTasks);
                //
                // repository = new BinaryTaskRepository();
                // repository.saveTasks(testTasks);
                
                var toDo = new ToDo();
                
                toDo.print();
            }
        }
    }
}