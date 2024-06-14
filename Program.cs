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
            Console.WriteLine("Enter your username");
            username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            password = Console.ReadLine();
            userController.CreateUser(username, password);
            userController.Login();
            menu.displayProgramMenu(userController.getUser(username) );
                
            Console.WriteLine("Choose:\n1. register \n 2. log in \n 3. exit");

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
