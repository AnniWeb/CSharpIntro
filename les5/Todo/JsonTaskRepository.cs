using System;
using System.IO;
using System.Text.Json;

namespace les5
{
    public class JsonTaskRepository : ITaskRepository
    {
        private string FileName = "tasks";
        private string Ext = "json";
        
        public Task[] getTasks(string file)
        {
            if ($"{FileName}.{Ext}" != Path.GetFileName(file))
            {
                throw new ArgumentException("Некорректный файл");
            }

            string json = File.ReadAllText(file);
            Task[] tasks = JsonSerializer.Deserialize<Task[]>(json) ?? new Task[0];

            return tasks;
        }

        public void saveTasks(Task[] tasks)
        {
            string fileName = $"{FileName}.{Ext}";

            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(fileName, json);
        }
    }
}