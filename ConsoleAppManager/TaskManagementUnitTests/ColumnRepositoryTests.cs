using TaskManagementEngine.Models;
using TaskManagementEngine.Repositories;

namespace TaskManagementEngine.Tests
{
    [TestFixture]
    public class ColumnRepositoryTests
    {
        [Test]
        public void TestAddColumn()
        {
            // Arrange
            var columnRepository = new ColumnRepository();
            var column = new Column { Id = 1, Name = "Column 1" };

            // Act
            columnRepository.AddColumn(column);

            // Assert
            var resultColumn = columnRepository.GetColumnByName("Column 1");
            Assert.That(resultColumn, Is.EqualTo(column));
        }

        // Add more test methods for other functionalities in ColumnRepository class.
    }
}
