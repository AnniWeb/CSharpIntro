namespace les5
{
    public interface ITaskRepository
    {
        public Task[] getTasks(string file);
        public void saveTasks(Task[] tasks);
    }
}