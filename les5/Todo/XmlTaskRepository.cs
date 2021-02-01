using System;
using System.IO;
using System.Xml.Serialization;

namespace les5
{
    public class XmlTaskRepository : ITaskRepository
    {
        private string FileName = "tasks";
        private string Ext = "xml";
        
        public Task[] getTasks(string file)
        {
            if ($"{FileName}.{Ext}" != Path.GetFileName(file))
            {
                throw new ArgumentException("Некорректный файл");
            }

            string xml = File.ReadAllText(file);
            var serializer = new XmlSerializer(typeof(Tasks));
            var reader = new StringReader(xml);
            
            var listTasks = (Tasks)serializer.Deserialize(reader);
            Task[] tasks = listTasks.TaskItems;

            return tasks;
        }

        public void saveTasks(Task[] tasks)
        {
            string fileName = $"{FileName}.{Ext}";
            var listTasks = new Tasks();
            listTasks.TaskItems = tasks;

            var serializer = new XmlSerializer(typeof(Tasks));
            var writer = new StringWriter();

            serializer.Serialize(writer, listTasks);
            
            string xml = writer.ToString();
            
            File.WriteAllText(fileName, xml);
        }
    }
}