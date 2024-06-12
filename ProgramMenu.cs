using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.classes;

namespace TaskScheduler
{
    internal class ProgramMenu
    {


        public void displayProgramMenu(User authenticatedUser)
        {
            Console.WriteLine("Welcome to your task scheduler! Please choose an option:");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Execute all tasks");
            Console.WriteLine("3. Remove a task");
            Console.WriteLine("4. Display all tasks");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Adding task: ");
                    Console.Write("Name: ");
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

                    //authenticatedUser.myTaskController.addTask(name, priority, deadline);
                    break;
                case "2":
                    Console.WriteLine("Executing All Tasks: ");

                    // logic for executing task

                   // authenticatedUser.myTaskController.executeAllTasks();
                    break;
                case "3":
                    Console.Write("Removing Task: ");

                    // logic for removing task
                    int index = 0;
                    bool isValidIndex = false;
                    while (!isValidIndex)
                    {
                        Console.Write("Enter an index to remove a task: ");
                        string indexInput = Console.ReadLine();
                        isValidIndex = int.TryParse(indexInput, out index);

                        if (!isValidIndex)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for an index.");
                        }
                    }

                    //authenticatedUser.myTaskController.removeTask(index);
                    break;
                case "4":
                    Console.WriteLine("Displaying All Tasks: ");

                    // logic for displaying task

                    //authenticatedUser.myTaskController.displayTasks();
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
