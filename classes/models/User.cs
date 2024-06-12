using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.classes.controllers;

namespace TaskScheduler.classes
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public TaskController myTaskController { get; set; }


        public User(string name, string pwd, TaskController myTaskCtrl)
        {
            username = name;
            password = pwd;
            myTaskController = myTaskCtrl;
        }


    }

}

