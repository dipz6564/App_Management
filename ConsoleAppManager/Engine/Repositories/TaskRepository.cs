
using TaskManagementEngine.Interfaces;

namespace TaskManagementEngine.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<Models.Task> _tasks;

        public TaskRepository()
        {
            _tasks = new List<Models.Task>();
        }

        public void AddTask(Models.Task task)
        {
            task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(task);
        }

        public void UpdateTask(Models.Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.Description = task.Description;
                existingTask.Deadline = task.Deadline;
                existingTask.IsFavorite = task.IsFavorite;
            }
        }

        public void DeleteTask(int taskId)
        {
            var taskToDelete = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToDelete != null)
            {
                _tasks.Remove(taskToDelete);
            }
        }

        public Models.Task GetTaskById(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _tasks;
        }
    }
}
