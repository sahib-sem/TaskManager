namespace TaskManager
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            Task tsk1 = new Task() { Name = "clean house" , Description = "clean my house" , 
            Catagory = TaskCatagory.Personal, 

            IsCompleted = false
            };
            Task tsk2 = new Task
            {
                Name = "Finish report",
                Description = "Complete the report",
                Catagory = TaskCatagory.Work,
                IsCompleted = false
            };
            Task tsk3 = new Task
            {
                Name = "Buy groceries",
                Description = "Get groceries",
                Catagory = TaskCatagory.Other,
                IsCompleted = false
            };

            TaskManager mgt = new TaskManager("C:\\Users\\PC\\source\\repos\\TaskManager/tasks.txt");
            
           


            await mgt.AddTask(tsk1);
            await mgt.AddTask(tsk2);
            await mgt.AddTask(tsk3);
            await mgt.updateTask("clean house", "new description", true);
            await mgt.printTasks();
            await mgt.filter(TaskCatagory.Personal);

            return 0;
            


        }
    }
}