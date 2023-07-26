using System;

namespace TaskManagementEngine.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(string message) : base(message)
        {
        }
    }

    public class ColumnNotFoundException : Exception
    {
        public ColumnNotFoundException(string message) : base(message)
        {
        }
    }

    // Add more custom exceptions as needed for the application
}
