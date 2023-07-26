using TaskManagementEngine.Repositories;

namespace TaskManagementEngine.Tests
{
    [TestFixture]
    public class TaskRepositoryTests
    {
        [Test]
        public void TestAddTask()
        {
            // Arrange
            var taskRepository = new TaskRepository();
            var task = new Models.Task { Id = 1, Name = "Task 1", Description = "Description", Deadline = DateTime.Now, IsFavorite = false };

            // Act
            taskRepository.AddTask(task);

            // Assert
            var resultTask = taskRepository.GetTaskById(1);
            Assert.That(resultTask, Is.EqualTo(task));
        }

        [Test]
        public void TestUpdateTask()
        {
            // Arrange
            var taskRepository = new TaskRepository();
            var task = new Models.Task { Id = 1, Name = "Task 1", Description = "Description", Deadline = DateTime.Now, IsFavorite = false };
            taskRepository.AddTask(task);
            var updatedTask = new Models.Task { Id = 1, Name = "Updated Task", Description = "Updated Description", Deadline = DateTime.Now.AddDays(2), IsFavorite = true };

            // Act
            taskRepository.UpdateTask(updatedTask);

            // Assert
            var resultTask = taskRepository.GetTaskById(1);
            Assert.Multiple(() =>
            {
                Assert.That(resultTask.Name, Is.EqualTo(updatedTask.Name));
                Assert.That(resultTask.Description, Is.EqualTo(updatedTask.Description));
                Assert.That(resultTask.Deadline, Is.EqualTo(updatedTask.Deadline));
                Assert.That(resultTask.IsFavorite, Is.EqualTo(updatedTask.IsFavorite));
            });
        }

        [Test]
        public void TestDeleteTask()
        {
            // Arrange
            var taskRepository = new TaskRepository();
            var task = new Models.Task { Id = 1, Name = "Task 1", Description = "Description", Deadline = DateTime.Now, IsFavorite = false };
            taskRepository.AddTask(task);

            // Act
            taskRepository.DeleteTask(1);

            // Assert
            var resultTask = taskRepository.GetTaskById(1);
            Assert.That(resultTask, Is.Null);
        }

        // Add more test methods for other functionalities in TaskRepository class.
    }
}
