using System;

namespace ConsoleAppManager.Services
{
    public class ConsoleOutputService
    {
        public void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Task Management App!");
            Console.WriteLine();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add new task");
            Console.WriteLine("2. Edit task");
            Console.WriteLine("3. Delete task");
            Console.WriteLine("4. View task details");
            Console.WriteLine("5. Add column");
            Console.WriteLine("6. Move task");
            Console.WriteLine("7. Sort tasks");
            Console.WriteLine("8. Exit");
        }

        public void ShowInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        public void ShowExitMessage()
        {
            Console.WriteLine("Exiting the Task Management App...");
        }
    }
}
