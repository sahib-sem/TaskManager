using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace TaskManager
{
    internal class TaskManager
    {

        string filePath;

        public TaskManager(string fileP)
        {
            
            this.filePath = fileP;
        }

        private async Task<bool> SaveTasks(List<Task> tasks)
        {   
            List<string> lines = new List<string>();
            foreach (var task in tasks)
            {
                lines.Add(TaskToString(task));

            }

            await File.WriteAllLinesAsync(filePath, lines.ToArray());

            return true;

        }

        public async Task<List<Task>> LoadTasks()
        {
      
            var TaskFromFile = await File.ReadAllLinesAsync(this.filePath);
            List<Task> tasks = new List<Task>();
            
            foreach (string line  in TaskFromFile)
            {
                if (line.Length > 0)
                {
                    tasks.Add(CreateTaskFromString(line));
                }
                
            }

            
            return tasks;

        }

        public async Task<bool> AddTask(Task task)
        {
            
            List<Task> tasks = await LoadTasks();

            tasks.Add(task);
            await SaveTasks(tasks);
            return true;


        }

        public async Task<bool> updateTask(string taskName, string description , bool taskStatus)
        {
            var tasks = await LoadTasks();
            foreach(var task in tasks)
            {
                if (task.Name == taskName)
                {
                    task.IsCompleted = taskStatus;
                    task.Description = description;
                    break;
                }
            }

            await SaveTasks(tasks);

            return true;

        }

        public Task CreateTaskFromString(string line)
        {
            string[] TaskProperties = line.Split("|");


            Task newTask = new Task() {
                Name = TaskProperties[0],
                Catagory = (TaskCatagory)Enum.Parse(typeof(TaskCatagory), TaskProperties[1]),
                Description = TaskProperties[2],
                IsCompleted = bool.Parse(TaskProperties[3])
     
            };

            return newTask;
        }

        public string TaskToString(Task task)
        {
            return $"{task.Name}|{task.Catagory}|{task.Description}|{task.IsCompleted}";
        }

        public async Task<int> filter(TaskCatagory catagory)
        {

            var task = await LoadTasks();

            var filteredTask = task.Where(t => t.Catagory == catagory).ToList();

            return 0;


        }   

        public async Task<bool> printTasks()
        {
            Console.WriteLine("you have the following tasks");
            Console.WriteLine("task Name | task catagory | task description | status");
             
            var tasks = await LoadTasks();
           

            foreach(var task in tasks)
            {
                Console.WriteLine(TaskToString(task));
            }

            return true;

        }
    }
}
