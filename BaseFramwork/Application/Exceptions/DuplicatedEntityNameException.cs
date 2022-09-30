namespace BaseFramework.Application.Exceptions;

public class DuplicatedEntityNameException : ApplicationBaseException
{
    public DuplicatedEntityNameException()
    {

    }
    public DuplicatedEntityNameException(string? message) : base(message)
    {
    }
}