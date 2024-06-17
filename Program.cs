using System;
using TaskScheduler.classes.controllers;

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

                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        userController.CreateUser(username, password);
                        if (userController.Login(username, password) != null)
                        {
                            menu.displayProgramMenu(userController.getUser(username));
                        }

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
                        Console.WriteLine("Press any key to exit");
                        Console.ReadLine();
                        return;
                    default:
                        throw new Exception("\n\nInvalid choice");

                }
            }
        }
    }
}
