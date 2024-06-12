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



            User userObj = Users.Find(u => u.username == username_input && u.password == password_input);
            Console.WriteLine($"\n\n**********Welcome to your task scheduler, {username_input}!***********\n\n");
            if (userObj != null)
            {
                while (true)
                {
                    Console.WriteLine("1. Add Task");
                    Console.WriteLine("2. Execute");
                    Console.WriteLine("3. Remove");
                    Console.WriteLine("4. Display");
                    Console.WriteLine("5. Logout");

                    ProgramMenu menu = new ProgramMenu();
                    menu.RunSwitchCase(userObj);
                }
                
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
