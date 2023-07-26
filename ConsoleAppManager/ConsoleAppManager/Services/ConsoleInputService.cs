using System;
using TaskManagementEngine;

namespace ConsoleAppManager.Services
{
    public class ConsoleInputService
    {
        public MainMenuOption GetMainMenuInput()
        {
            Console.WriteLine("Enter the option number from the menu:");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                if (Enum.IsDefined(typeof(MainMenuOption), option))
                {
                    return (MainMenuOption)option;
                }
            }

            return MainMenuOption.Invalid;
        }

        public void WaitForUserConfirmation()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue or 'Q' to quit:");
            var key = Console.ReadKey(intercept: true);
            if (key.KeyChar == 'q' || key.KeyChar == 'Q')
            {
                Console.WriteLine("Exiting the Task Management App...");
                Environment.Exit(0);
            }
            Console.WriteLine();
        }
    }
}
