namespace BaseFramework.Application.Exceptions;

public class ApplicationBaseException : Exception
{
    public ApplicationBaseException()
    {

    }
    public ApplicationBaseException(string? message) : base(message)
    {
    }
}