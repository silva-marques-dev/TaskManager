using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Repositories;
//Contrato que define como tarefas podem ser armazenadas e recuperadas.
/// O Domain define O QUE precisa ser feito, não COMO.
public interface ITaskRepository
{
    //Adiciona uma nova tarefa ao repositório.
    void Add(TaskItem task);
    //Retorna todas as tarefas armazenadas.
    IEnumerable<TaskItem> GetAll();
    //Busca uma tarefa pelo seu Id e Retorna null se não encontrar.
    TaskItem? GetById(Guid id);
}
