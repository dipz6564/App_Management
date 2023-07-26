using TaskManagementEngine.Models;

namespace TaskManagementEngine
{
    public class TaskManager
    {
        public void MoveTaskToColumn(Models.Task task, Column destinationColumn)
        {
            if (task == null || destinationColumn == null)
            {
                return;
            }

            // Remove the task from its current column (if any)
            var currentColumn = GetColumnContainingTask(task);
            if (currentColumn != null)
            {
                currentColumn.Tasks.Remove(task);
            }

            // Add the task to the destination column
            destinationColumn.Tasks.Add(task);
        }

        public void SortTasksAlphabetically(Column column)
        {
            if (column == null)
            {
                return;
            }

            column.Tasks = column.Tasks.OrderBy(t => t.Name).ThenByDescending(t => t.IsFavorite).ToList();
        }

        private Column GetColumnContainingTask(Models.Task task)
        {
            return GetAllColumns().FirstOrDefault(c => c.Tasks.Contains(task));
        }

        private IEnumerable<Column> GetAllColumns()
        {
            // In a real-world application, we would likely use a repository to retrieve columns from a data source
            // For the sake of simplicity, this example assumes a static list of columns
            return new List<Column>();
        }
    }
}
