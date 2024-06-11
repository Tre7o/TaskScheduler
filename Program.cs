using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskScheduler.classes.controllers;

namespace TaskScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskController controller = new TaskController();

            Console.WriteLine("Please enter the task details");

            int exitNumber = 0;

            while (exitNumber == 0)
            {
                Console.WriteLine("Task Name: ");
                String name = Console.ReadLine();

                // Reading task priority
                int priority = 0;
                bool isValidPriority = false;
                while (!isValidPriority)
                {
                    Console.WriteLine("Task Priority: ");
                    string priorityInput = Console.ReadLine();
                    isValidPriority = int.TryParse(priorityInput, out priority);

                    if (!isValidPriority)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for task priority.");
                    }
                }

                DateTime deadline = DateTime.Now;
                bool isValidDate = false;

                while (!isValidDate)
                {
                    Console.WriteLine("Task Deadline e.g. MM/DD/YYYY  ");
                    string dateInput = Console.ReadLine();
                    isValidDate = DateTime.TryParse(dateInput, out deadline);

                    if (!isValidDate)
                    {
                        Console.WriteLine("Please enter a valid date for the deadline e.g. MM/DD/YYYY");
                    }
                }

                controller.addTask(name, priority, deadline);

                Console.WriteLine("Enter 0 to continue adding tasks or any other number to stop");

                string exitInput = Console.ReadLine();
                bool isValidExitNumber = false;
                isValidExitNumber = int.TryParse(exitInput, out exitNumber);

            }

            controller.displayTasks();
            Console.WriteLine("\n");
            controller.executeAllTasks();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            
            Environment.Exit(0);

        }
    }
}
