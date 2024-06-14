using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.classes.interfaces
{
    internal interface ITaskExecutor
    {
        void ExecuteTask(Task task);
    }
}
