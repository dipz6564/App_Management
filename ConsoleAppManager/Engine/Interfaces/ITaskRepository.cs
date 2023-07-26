using System.Collections.Generic;

namespace TaskManagementEngine.Interfaces
{
    public interface ITaskRepository
    {
        void AddTask(Models.Task task);
        void UpdateTask(Models.Task task);
        void DeleteTask(int taskId);
        Models.Task GetTaskById(int taskId);
        IEnumerable<Models.Task> GetAllTasks();
    }
}
