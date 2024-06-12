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
                TaskController taskController = new TaskController();
                userController.CreateUser(username, password);
                userController.Login();
                menu.displayProgramMenu(userController.getUser(username) );


            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            Environment.Exit(0);

        }
    }
}
