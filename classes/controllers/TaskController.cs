using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskScheduler.classes.interfaces;

namespace TaskScheduler.classes.controllers
{
   
    public class TaskController : TaskExecutor
    {

        List<Task> tasks = new List<Task>();

        public void addTask(string name, int priority, DateTime deadline)
        {
            tasks.Add(new Task(name, priority, deadline));
        }

        public void removeTask(int index)
        {
            tasks.RemoveAt(index);
        }

        public Task getNextTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No Tasks Available\n");
            }
            try {
               
                tasks = tasks.OrderByDescending(t => t._priority).ToList();
                Task nextTask = tasks.First();
                tasks.RemoveAt(0);
                return nextTask;

            } catch (Exception e)
            {
                Console.WriteLine("\nNo more items in the task list: " + e.Message);
                return null;
            }
          }

        public void executeAllTasks()
        {

            //while (tasks.Count > 0)
            for(int i = tasks.Count; i>=0; i-- )
            {
                Task task = getNextTask();
                executeTask(task);
            }
        }


        public void displayTasks()
        {
            int count = 0;
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

        public void executeTask(Task task)
        {
            Console.WriteLine("Executing "+task);
        }
    }
}
