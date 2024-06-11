using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    internal class Task
    {
        public string _taskName { get; set; }
        public int _priority { get; set; }
        public DateTime _deadline { get; set; }

        public Task(string taskName, int priority, DateTime deadline)
        {
            _taskName = taskName;
            _priority = priority;
            _deadline = deadline;
        }

        public override string ToString()
        {
            return $"Name: {_taskName}, Priority: {_priority}";
        }

    }
}
