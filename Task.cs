using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Task
    {

        public  string  Name { get; set; }

        public string Description { get; set; }

        public TaskCatagory Catagory { get; set; }

        public bool IsCompleted { get; set; }
    }
}
