using TaskManager.Application.Exceptions;
using TaskManager.Application.Repositories;
using TaskManager.Application.Services;

// Cria o repositório em memória
var repository = new InMemoryTaskRepository();

// Cria o serviço de aplicação
var taskService = new TaskService(repository);

try
{
    // Cria uma tarefa
    taskService.CreateTask("Estudar C#");

    // Obtém a tarefa criada
    var task = taskService.GetAll().First();

    // Conclui a tarefa
    taskService.CompleteTask(task.Id);

    // Tenta concluir novamente (erro esperado)
    taskService.CompleteTask(task.Id);
}
catch (ApplicationExceptionBase ex)
{
    // Exibe apenas a mensagem amigável para o usuário
    Console.WriteLine($"⚠️ {ex.Message}");
}

// Exibe o estado final das tarefas
foreach (var task in taskService.GetAll())
{
    Console.WriteLine(
        $"Título: {task.Title} | Concluída: {task.IsCompleted}"
    );
}



