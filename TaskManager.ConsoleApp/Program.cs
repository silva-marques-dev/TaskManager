using TaskManager.Application.Services;

var taskService = new TaskService();

taskService.CreateTask("Estudar C#");
taskService.CreateTask("Aprender SOLID");

foreach (var task in taskService.GetAll())
{
    Console.WriteLine($"- {task.Title} | Concluída: {task.IsCompleted}");
}

Console.ReadLine();

