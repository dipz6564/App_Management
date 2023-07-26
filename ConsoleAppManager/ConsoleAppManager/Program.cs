using ConsoleAppManager.Services;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementEngine;
using TaskManagementEngine.Interfaces;
using TaskManagementEngine.Repositories;

namespace ConsoleAppManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ITaskRepository, TaskRepository>()
                .AddSingleton<IColumnRepository, ColumnRepository>()
                .AddSingleton<TaskManager>()
                .AddSingleton<TaskManagementService>()
                .AddSingleton<ConsoleInputService>()
                .AddSingleton<ConsoleOutputService>()
                .BuildServiceProvider();

            // Resolve services
            var taskManagementService = serviceProvider.GetService<TaskManagementService>();
            var consoleInputService = serviceProvider.GetService<ConsoleInputService>();
            var consoleOutputService = serviceProvider.GetService<ConsoleOutputService>();

            // Show welcome message
            consoleOutputService.ShowWelcomeMessage();

            // Main loop
            while (true)
            {
                consoleOutputService.ShowMainMenu();
                var userInput = consoleInputService.GetMainMenuInput();

                switch (userInput)
                {
                    case MainMenuOption.AddTask:
                        taskManagementService.AddNewTask();
                        break;
                    case MainMenuOption.EditTask:
                        taskManagementService.EditTask();
                        break;
                    case MainMenuOption.DeleteTask:
                        taskManagementService.DeleteTask();
                        break;
                    case MainMenuOption.ViewTaskDetails:
                        taskManagementService.ViewTaskDetails();
                        break;
                    case MainMenuOption.AddColumn:
                        taskManagementService.AddColumn();
                        break;
                    case MainMenuOption.MoveTask:
                        taskManagementService.MoveTask();
                        break;
                    case MainMenuOption.SortTasks:
                        taskManagementService.SortTasks();
                        break;
                    case MainMenuOption.Exit:
                        consoleOutputService.ShowExitMessage();
                        return;
                    default:
                        consoleOutputService.ShowInvalidInputMessage();
                        break;
                }
                consoleInputService.WaitForUserConfirmation();
            }
        }
    }
}
