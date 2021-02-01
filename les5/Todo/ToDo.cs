using System;
using System.IO;

namespace les5
{
    public class ToDo
    {
        public Task[] Tasks { get; private set; } = new Task[0];

        private ITaskRepository Repository;
        
        public void setTasks(Task[] tasks)
        {
            Tasks = tasks;
        }

        public bool LoadData()
        {
            string[] subPath = Directory.GetFileSystemEntries(Directory.GetCurrentDirectory(), "tasks.*");
            string file = String.Empty;
            
            
            for (int i = 0; i < subPath.Length; i++)
            {
                if (File.Exists(subPath[i]))
                {
                    string extension = Path.GetExtension(subPath[i]);
                    switch(extension)
                    {
                        case ".json":
                            Repository = new JsonTaskRepository();
                            file = subPath[i];
                            break;
                        case ".xml":
                            Repository = new XmlTaskRepository();
                            file = subPath[i];
                            break;
                        case ".bin":
                            Repository = new BinaryTaskRepository();
                            file = subPath[i];
                            break;
                    }

                    if (file != String.Empty)
                    {
                        break;
                    }
                }
            }
            
            if (file != String.Empty)
            {
                try
                {
                    Tasks = Repository.getTasks(file);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            return false;
        }

        public void toggleMark(int taskNumber, out string error)
        {
            taskNumber--;
            error = String.Empty;
            if (Tasks.Length > taskNumber || taskNumber < 0)
            {
                Task task = Tasks[taskNumber];
                
                task.SetIsDone(!task.IsDone);
                
            }
            else
            {
                error = "Задача не найдена";
            }
            Repository.saveTasks(Tasks);
        }

        public void printTasks()
        {
            Console.WriteLine("Список задач: ");
            for (int i = 0; i < Tasks.Length; i++)
            {
                string mark = Tasks[i].IsDone ? "[x]" : "[ ]";
                Console.WriteLine($"{(i+1).ToString("D2")}. {mark} {Tasks[i].Title}");
            }
            Console.WriteLine(new String('_', 100));
            Console.WriteLine();
        }
        
        
        public void print()
        {
            
            if (LoadData())
            {
                while (true)
                {
                    printTasks();
                    try
                    { 
                        Console.WriteLine("Введите номер задачи, у которой нужно поменять флаг");
                        int taskNumber = Int32.Parse(Console.ReadLine());
                        toggleMark(taskNumber, out string error);
                        Console.WriteLine(error);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Список задач пуст");
                return;
            }
        }
        
    }
}