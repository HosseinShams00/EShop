namespace BaseFramework.Application.Exceptions;

public class EntityNotFoundException : ApplicationBaseException
{
    public EntityNotFoundException()
    {

    }
    public EntityNotFoundException(string? message) : base(message)
    {
    }
}
