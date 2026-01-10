namespace TaskManager.Application.Exceptions;

// Exceção base da camada Application.
// Representa erros de regra de negócio percebidos pela aplicação.
public class ApplicationExceptionBase : Exception
{
    
    // Construtor padrão que recebe uma mensagem amigável.
    public ApplicationExceptionBase(string message)
        : base(message)
    {
    }
}
