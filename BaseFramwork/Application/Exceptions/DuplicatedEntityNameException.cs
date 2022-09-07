namespace BaseFramwork.Application.Exceptions;

public class DuplicatedEntityNameException : ApplicationException
{
    public DuplicatedEntityNameException()
    {

    }
    public DuplicatedEntityNameException(string? message) : base(message)
    {
    }
}