using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    //Lista privada que simula um banco de dados em memória
    private readonly List<TaskItem> _tasks = new();

    // Adiciona uma tarefa à lista.
    public void Add(TaskItem task)
    {
        _tasks.Add(task);
    }

    // Retorna todas as tarefas armazenadas.
    public IEnumerable<TaskItem> GetAll()
    {
        return _tasks;
    }

    //Busca uma tarefa pelo Id.
    // Se não existir, retorna null
    public TaskItem? GetById(Guid id)
    {
        // Procura a primeira tarefa cujo Id seja igual ao informado
        return _tasks.FirstOrDefault(t => t.Id == id);
    }
}

