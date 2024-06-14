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
    public class Program
    {
        static void Main(string[] args)
        {
            string username;
            string password;

            UserController userController = new UserController();
            ProgramMenu menu = new ProgramMenu();

            // Registering a new user
            Console.WriteLine("Register to continue");
            Console.WriteLine("Enter your username");
            username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            password = Console.ReadLine();

            userController.CreateUser(username, password);
            if (userController.Login() !=  null)
            {
                menu.displayProgramMenu(userController.getUser(username));
            }
                    
            Console.WriteLine("Choose:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Log in");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    int trials = 1;
                    while (trials<=3)
                    {
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        userController.CreateUser(username, password);
                        trials++;
                    }
                    break;

                case "2":
                    userController.Login();
                    menu.displayProgramMenu(userController.getUser(username));
                    break;

                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    throw new Exception("\n\nInvalid choice");

            }
            
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            Environment.Exit(0);

        }
    }
}
