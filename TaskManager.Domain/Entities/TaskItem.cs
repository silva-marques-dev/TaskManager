namespace TaskManager.Domain.Entities
{
    public class TaskItem
    {
        // Entidade que representa uma tarefa.
        // Contém regras de negócio e comportamento.

        // Identificador único da tarefa
        public Guid Id { get; private set; }
        // Título da tarefa
        public string Title { get; private set; }
        // Indica se a tarefa foi concluída
        public bool IsCompleted { get; private set; }

        // Construtor da entidade.
        public TaskItem(string title)
        {
            // Valida o título antes de criar a tarefa
            ValidateTitle(title);

            // Gera um identificador único
            Id = Guid.NewGuid();

            // Define o título
            Title = title;

            // Toda tarefa começa como não concluída
            IsCompleted = false;
        }
        // Marca a tarefa como concluída.
        // Regra de negócio encapsulada na entidade.
        public void Complete()
        {
            // Regra de negócio:
            // Não é permitido concluir uma tarefa que já está concluída
            if (IsCompleted)
            {
                throw new InvalidOperationException(
                    "A tarefa já foi concluída e não pode ser concluída novamente."
                );
            }

            // Caso esteja válida, altera o estado interno
            IsCompleted = true;
        }
        //Valida regras relacionadas ao título da tarefa.
        private void ValidateTitle(string title)
        {
            // Verifica se o título é nulo, vazio ou só espaços
            if (string.IsNullOrWhiteSpace(title))
                // Lança exceção se a regra for violada
                throw new ArgumentException("O título da tarefa é obrigatório.");
        }
    }
}
