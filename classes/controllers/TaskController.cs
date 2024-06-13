using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.classes.interfaces;

namespace TaskScheduler.classes.controllers
{
   
    public class TaskController 
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

        public List<Task> getNextTask()
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
                List<Task> task = getNextTask();
                foreach (Task t in tasks)
                {
                    Console.WriteLine("Executing " + t._taskName);
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

    }
}
