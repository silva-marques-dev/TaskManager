using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();

        public void CreateTask(string title)
        {
            var task = new TaskItem(title);
            _tasks.Add(task);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }
    }
}
