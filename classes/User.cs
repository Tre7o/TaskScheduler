﻿using System;
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
        TaskController myTaskcontroller = new TaskController();


        public User(string name, string pwd, TaskController tskCtrl)
        {
            username = name;
            password = pwd;
            myTaskcontroller = tskCtrl;
        }


    }

}

