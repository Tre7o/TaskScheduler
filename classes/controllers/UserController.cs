using log4net;
using System;
using System.Collections.Generic;
using TaskScheduler.log4net;

namespace TaskScheduler.classes.controllers
{
    internal class UserController
    {
        Dictionary<string, User> users = new Dictionary<string, User>();
        private readonly TestLogger log;

        public UserController()
        {
            log = TestLogger.GetInstance();
        }

        //CREATE USER
        public void CreateUser(string username, string password)
        {
            ILog logger = log.TestLog4Net();
            try
            {
                users.Add(username, new User(username, password));
                Console.WriteLine("User account created successfully!");
            }
            catch (Exception e)
            {
                // Console.WriteLine("Sorry user already exists");
                logger.Error(e);
            }
        }

        //LOGIN
        public string[] Login(string username_input, string password_input)
        {

            int trials = 0;

            ILog logger = log.TestLog4Net();

            //allow a maximum of 3 trials for logging in
            while (trials == 0 || trials < 3)
            {

                try
                {
                    if ((username_input == users[username_input].username) && (password_input == users[username_input].password))
                    {
                        Console.WriteLine($"\n**********Welcome to your task scheduler, {username_input}!***********\n");
                        trials = 0;
                        return new string[] { username_input, password_input };
                    }
                }
                catch (Exception e)
                {
                    logger.Error("Invalid Credentials");
                    trials++;
                    return null;
                }
                /* if ((username_input == users[username_input].username) && (password_input == users[username_input].password)){
                    Console.WriteLine($"\n**********Welcome to your task scheduler, {username_input}!***********\n");
                    trials = 0;
                    return new string[] { username_input, password_input};
                }else{
                    Console.WriteLine("Invalid credentials!!!");
                    trials++;
                    return null;
                } */

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

