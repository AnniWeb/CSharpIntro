using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace les5
{
    public class BinaryTaskRepository : ITaskRepository
    {
        private string FileName = "tasks";
        private string Ext = "bin";
        
        public Task[] getTasks(string file)
        {
            if ($"{FileName}.{Ext}" != Path.GetFileName(file))
            {
                throw new ArgumentException("Некорректный файл");
            }
            var formatter = new BinaryFormatter();
            var fs = new FileStream(file, FileMode.Open);
            Task[] tasks = (Task[])formatter.Deserialize(fs);
            fs.Close();

            return tasks;
        }

        public void saveTasks(Task[] tasks)
        {
            string fileName = $"{FileName}.{Ext}";

            var formatter = new BinaryFormatter();
            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(fs, tasks);
            fs.Close();
        }
    }
}