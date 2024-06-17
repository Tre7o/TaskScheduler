using System;
using TaskScheduler.classes;

namespace TaskScheduler
{
    internal class ProgramMenu
    {

        public void displayProgramMenu(User authenticatedUser)
        {
            while (true)
            {
                Console.WriteLine("\n\nPlease choose an option:");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. Execute all tasks");
                Console.WriteLine("3. Remove a task");
                Console.WriteLine("4. Display all tasks\n");
                Console.WriteLine("5. Logout");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Adding task: ");
                        Console.Write("Task name: ");
                        String name = Console.ReadLine();

                        // Reading and validating task priority

                        int priority = 0;
                        bool isValidPriority = false;
                        while (!isValidPriority)
                        {
                            Console.Write("Priority: ");
                            string priorityInput = Console.ReadLine();
                            isValidPriority = int.TryParse(priorityInput, out priority);

                            if (!isValidPriority)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer for task priority.");
                            }
                        }

                        // Reading and validating task deadline

                        DateTime deadline = DateTime.Now;
                        bool isValidDate = false;
                        while (!isValidDate)
                        {
                            Console.WriteLine("Deadline e.g. DD/MM/YYYY  ");
                            string dateInput = Console.ReadLine();
                            isValidDate = DateTime.TryParse(dateInput, out deadline);

                            if (!isValidDate)
                            {
                                Console.WriteLine("Please enter a valid date for the deadline e.g. DD/MM/YYYY");
                            }
                        }

                        // logic adding task

                        authenticatedUser.myTaskcontroller.addTask(name, priority, deadline);
                        break;
                    case "2":
                        Console.WriteLine("Executing All Tasks: ");
                        // logic for executing task
                        authenticatedUser.myTaskcontroller.executeAllTasks();
                        break;

                    case "3":
                        Console.Write("Enter the task to be removed ");

                        // logic for removing task
                        string task_name_input = Console.ReadLine();

                        authenticatedUser.myTaskcontroller.removeTask(task_name_input);
                        break;
                    case "4":
                        Console.WriteLine("Displaying All Tasks: ");

                        // logic for displaying task

                        authenticatedUser.myTaskcontroller.displayTasks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
