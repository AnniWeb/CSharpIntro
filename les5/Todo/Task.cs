using System;

namespace les5
{
    [Serializable]
    public class Task
    {
        public string Title { get; set; }
        public bool IsDone { set; get; }

        public Task() {}
        public Task(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }

        public void SetIsDone(bool isDone)
        {
            IsDone = isDone;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
    }
}