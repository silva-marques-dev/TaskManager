using TaskManager.Application.Exceptions;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services;

// Serviço de aplicação responsável por orquestrar
// os casos de uso relacionados a tarefas.
public class TaskService
{
    // Dependência do repositório de tarefas
    // Usamos a interface para respeitar o SOLID (DIP)
    private readonly ITaskRepository _repository;

    // Construtor do serviço.
    // Recebe o repositório via injeção de dependência.
    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

   // Cria uma nova tarefa.
    public void CreateTask(string title)
    {
        // Cria a entidade TaskItem (regra do Domain)
        var task = new TaskItem(title);

        // Adiciona a tarefa no repositório
        _repository.Add(task);
    }

    // Retorna todas as tarefas cadastradas.
    public IEnumerable<TaskItem> GetAll()
    {
        // Apenas delega a chamada para o repositório
        return _repository.GetAll();
    }

    // Conclui uma tarefa pelo seu identificador.
    public void CompleteTask(Guid taskId)
    {
        // Busca a tarefa no repositório pelo Id
        var task = _repository.GetById(taskId);

        // Caso a tarefa não exista, lança exceção de aplicação
        if (task is null)
        {
            throw new ApplicationExceptionBase(
                "A tarefa informada não foi encontrada."
            );
        }

        try
        {
            // Tenta concluir a tarefa
            // O Domain decide se isso é permitido
            task.Complete();
        }
        catch (InvalidOperationException ex)
        {
            // Captura a exceção técnica lançada pelo Domain
            // e converte para uma exceção amigável da Application
            throw new ApplicationExceptionBase(ex.Message);
        }
    }
}
