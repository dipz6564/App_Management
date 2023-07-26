using TaskManagementEngine.Models;
using TaskManagementEngine.Repositories;

namespace TaskManagementEngine.Tests
{
    [TestFixture]
    public class TaskManagerTests
    {
        [Test]
        public void TestSortTasksAlphabetically()
        {
            // Arrange
            var taskManager = new TaskManager();
            var taskRepository = new TaskRepository();
            var columnRepository = new ColumnRepository();
            var task1 = new Models.Task { Id = 1, Name = "Task B", Description = "Description", Deadline = System.DateTime.Now, IsFavorite = false };
            var task2 = new Models.Task { Id = 2, Name = "Task A", Description = "Description", Deadline = System.DateTime.Now, IsFavorite = false };
            var column = new Column { Id = 1, Name = "Column 1" };
            taskRepository.AddTask(task1);
            taskRepository.AddTask(task2);
            column.Tasks.Add(task1);
            column.Tasks.Add(task2);

            // Act
            taskManager.SortTasksAlphabetically(column);

            // Assert
            Assert.That(column.Tasks.First().Name, Is.EqualTo("Task A"));
        }

        //[Test]
        public void TestMoveTaskToColumn()
        {
            // Arrange
            var taskManager = new TaskManager();
            var taskRepository = new TaskRepository();
            var columnRepository = new ColumnRepository();
            var task = new Models.Task { Id = 1, Name = "Task 1", Description = "Description", Deadline = System.DateTime.Now, IsFavorite = false };
            var column1 = new Column { Id = 1, Name = "Column 1" };
            var column2 = new Column { Id = 2, Name = "Column 2" };
            taskRepository.AddTask(task);
            column1.Tasks.Add(task);

            // Act
            taskManager.MoveTaskToColumn(task, column2);
            Assert.Multiple(() =>
            {

                // Assert
                Assert.That(column1.Tasks, Does.Not.Contain(task));
                Assert.That(column2.Tasks, Does.Contain(task));
            });
        }

        // Add more test methods for other functionalities in TaskManager class.
    }
}
