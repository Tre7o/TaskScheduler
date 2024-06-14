using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.classes.controllers
{
    internal class UserController
    {
        Dictionary<string, User> users = new Dictionary<string, User>();

        //CREATE USER
        public void CreateUser(string username, string password)
        {
            try {
                users.Add(username, new User(username, password));
                Console.WriteLine("User account created successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry user already exists");
                Console.WriteLine(e.Message);
            }
        }

        //LOGIN
        public string[] Login()
        {
            string username_input;
            string password_input;
            int trials = 0;


            //allow a maximum of 3 trials for logging in

            while (trials == 0 || trials < 3)
            {
                Console.WriteLine("**********LOGIN***********");
                Console.WriteLine("Enter your username");
                username_input = Console.ReadLine();
                Console.WriteLine("Enter your password");
                password_input = Console.ReadLine();

               /* try {
                } catch (Exception e)
                {

                }*/
                if ((username_input == users[username_input].username) && (password_input == users[username_input].password)){
                    Console.WriteLine($"\n**********Welcome to your task scheduler, {username_input}!***********\n");
                    trials = 0;
                    return new string[] { username_input, password_input};
                }else{
                    Console.WriteLine("Invalid credentials!!!");
                    trials++;
                    return null;
                }

            }

            Console.WriteLine("Maximum trials reached. Login failed.");
            return null;
        }

        //GET USER
        public User getUser(string username)
        {
            return users[username];
        }


    }
}

