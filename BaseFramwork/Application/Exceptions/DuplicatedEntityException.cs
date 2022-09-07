namespace BaseFramwork.Application.Exceptions;

public class DuplicatedEntityException : ApplicationException
{
    public DuplicatedEntityException()
    {

    }
    public DuplicatedEntityException(string? message) : base(message)
    {
    }
}