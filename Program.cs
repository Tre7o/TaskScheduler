using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskScheduler.classes.controllers;
using TaskScheduler.classes;
using TaskScheduler.log4net;

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

            while (true)
            {

                Console.WriteLine("Choose:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Log in");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        /* int trials = 1;
                        while (trials<=3)
                        { */
                        // Registering a new user

                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        userController.CreateUser(username, password);
                        if (userController.Login(username, password) != null)
                        {
                            menu.displayProgramMenu(userController.getUser(username));
                        }

                        /*    trials++;
                        } */
                        break;

                    case "2":
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        if (userController.Login(username, password) != null)
                        {
                            menu.displayProgramMenu(userController.getUser(username));
                        }
                        break;

                    case "3":
                        return;
                    default:
                        throw new Exception("\n\nInvalid choice");

                }
            }
            
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            Environment.Exit(0);

        }
    }
}
