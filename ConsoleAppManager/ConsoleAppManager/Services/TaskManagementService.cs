using TaskManagementEngine.Interfaces;
using TaskManagementEngine.Models;

namespace TaskManagementEngine
{
    public class TaskManagementService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IColumnRepository _columnRepository;
        private readonly TaskManager _taskManager;

        public TaskManagementService(ITaskRepository taskRepository, IColumnRepository columnRepository, TaskManager taskManager)
        {
            _taskRepository = taskRepository;
            _columnRepository = columnRepository;
            _taskManager = taskManager;
        }

        public void AddNewTask()
        {
            Console.WriteLine("Enter task name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter task description:");
            var description = Console.ReadLine();

            Console.WriteLine("Enter task deadline (YYYY-MM-DD):");
            var deadlineInput = Console.ReadLine();
            if (!DateTime.TryParse(deadlineInput, out DateTime deadline))
            {
                Console.WriteLine("Invalid date format. Task not added.");
                return;
            }

            var newTask = new Models.Task
            {
                Name = name,
                Description = description,
                Deadline = deadline
            };

            _taskRepository.AddTask(newTask);
            Console.WriteLine("Task added successfully!");
        }

        public void EditTask()
        {
            Console.WriteLine("Enter the ID of the task you want to edit:");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid task ID format. Task not updated.");
                return;
            }

            var taskToEdit = _taskRepository.GetTaskById(taskId);
            if (taskToEdit == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Enter updated task name:");
            taskToEdit.Name = Console.ReadLine();

            Console.WriteLine("Enter updated task description:");
            taskToEdit.Description = Console.ReadLine();

            Console.WriteLine("Enter updated task deadline (YYYY-MM-DD):");
            var deadlineInput = Console.ReadLine();
            if (!DateTime.TryParse(deadlineInput, out DateTime deadline))
            {
                Console.WriteLine("Invalid date format. Task not updated.");
                return;
            }

            taskToEdit.Deadline = deadline;
            _taskRepository.UpdateTask(taskToEdit);
            Console.WriteLine("Task updated successfully!");
        }

        public void DeleteTask()
        {
            Console.WriteLine("Enter the ID of the task you want to delete:");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid task ID format. Task not deleted.");
                return;
            }

            var taskToDelete = _taskRepository.GetTaskById(taskId);
            if (taskToDelete == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            _taskRepository.DeleteTask(taskId);
            Console.WriteLine("Task deleted successfully!");
        }

        public void ViewTaskDetails()
        {
            Console.WriteLine("Enter the ID of the task you want to view details for:");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid task ID format.");
                return;
            }

            var task = _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine($"Task ID: {task.Id}");
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Deadline: {task.Deadline:yyyy-MM-dd}");
        }

        public void AddColumn()
        {
            Console.WriteLine("Enter the name of the new column:");
            var columnName = Console.ReadLine();

            var newColumn = new Column
            {
                Name = columnName
            };

            _columnRepository.AddColumn(newColumn);
            Console.WriteLine("Column added successfully!");
        }

        public void MoveTask()
        {
            Console.WriteLine("Enter the ID of the task you want to move:");
            if (!int.TryParse(Console.ReadLine(), out int taskId))
            {
                Console.WriteLine("Invalid task ID format. Task not moved.");
                return;
            }

            var taskToMove = _taskRepository.GetTaskById(taskId);
            if (taskToMove == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Enter the name of the destination column:");
            var destinationColumn = Console.ReadLine();
            var column = _columnRepository.GetColumnByName(destinationColumn);

            if (column == null)
            {
                Console.WriteLine("Column not found.");
                return;
            }

            _taskManager.MoveTaskToColumn(taskToMove, column);
            Console.WriteLine("Task moved successfully!");
        }

        public void SortTasks()
        {
            Console.WriteLine("Enter the name of the column to sort tasks:");
            var columnName = Console.ReadLine();
            var column = _columnRepository.GetColumnByName(columnName);

            if (column == null)
            {
                Console.WriteLine("Column not found.");
                return;
            }

            _taskManager.SortTasksAlphabetically(column);
            Console.WriteLine("Tasks sorted successfully!");
        }
    }
}
