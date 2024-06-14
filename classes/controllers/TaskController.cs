﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.classes.interfaces;

namespace TaskScheduler.classes.controllers
{
   
    public class TaskController: ITaskExecutor 
    {

        List<Task> tasks = new List<Task>();

        public void addTask(string name, int priority, DateTime deadline)
        {
            tasks.Add(new Task(name, priority, deadline));
        }

        public void removeTask(string task_name_input)
        {
            int index = tasks.IndexOf(tasks.Find(t =>task_name_input == t._taskName));
            tasks.RemoveAt(index);
        }

        public List<Task> orderByPrioity()
        {
            if (!(tasks.Count == 0))
            {
                Console.WriteLine($"{tasks.Count} tasks are available\n");
                List<Task> sortedTaskList = tasks.OrderByDescending(t => t._priority).ToList();
                return sortedTaskList;
            }
            return null;
          }

        public void executeAllTasks()
        { 
                List<Task> sortedTasks = orderByPrioity();
                foreach (Task t in sortedTasks)
                {
                    ExecuteTask(t);
                }
        }


        public void displayTasks()
        {
            int count = 1;
            foreach (Task task in tasks)
            {
                Console.WriteLine("Task " + count);
                Console.WriteLine("Name: "+task._taskName);
                Console.WriteLine("Deadline: " + task._deadline);
                Console.WriteLine("Priority: " + task._priority);
                Console.WriteLine("====================================================\n");
                count++;
            }
        }

        public void ExecuteTask(Task task)
        {
            Console.WriteLine("Executing " + task);
        }
    }
}
