using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskScheduler.classes.controllers;
using TaskScheduler.classes;

namespace TaskScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> Users = new List<User>();

            TaskController EdithController = new TaskController();
            User Edith = new User("Edith", "12345", EdithController);
            Users.Add(Edith);

            TaskController TrevorController = new TaskController();
            User Trevor = new User("Trevor", "145", TrevorController);
            Users.Add(Trevor);
            //TaskController controller = new TaskController();

            
            Console.WriteLine("**********LOGIN***********");
            Console.WriteLine("Enter your username");
            string username_input = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password_input = Console.ReadLine();
            User user_input = Users.Find(u => u.username == username_input && u.password == password_input);
            if (user_input != null)
            {
                Console.WriteLine($"\n\n**********Welcome to your task scheduler, {username_input}!***********\n\n");
                Console.WriteLine("Please enter task details");

                string exitCharacter = "0";

                while (exitCharacter == "0")
                {

                    Console.Write("Task Name: ");
                    String name = Console.ReadLine();

                    // Reading task priority
                    int priority = 0;
                    bool isValidPriority = false;
                    while (!isValidPriority)
                    {
                        Console.Write("Task Priority: ");
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
                        Console.WriteLine("Task Deadline e.g. DD/MM/YYYY  ");
                        string dateInput = Console.ReadLine();
                        isValidDate = DateTime.TryParse(dateInput, out deadline);

                        if (!isValidDate)
                        {
                            Console.WriteLine("Please enter a valid date for the deadline e.g. DD/MM/YYYY");
                        }
                    }

                    user_input.myTaskController.addTask(name, priority, deadline);

                    Console.WriteLine("Enter 0 to continue adding tasks or any other key to stop");

                    exitCharacter = Console.ReadLine();

                }

                user_input.myTaskController.displayTasks();
                Console.WriteLine("\n");
                user_input.myTaskController.executeAllTasks();
            }
            else
            {
                Console.WriteLine("invalid credentials");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            Environment.Exit(0);

        }
    }
}
