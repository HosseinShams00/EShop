namespace BaseFramwork.Application;

public class OperationResult
{
    public string Message { get; set; }
    public bool IsSuccess { get; set; }

    public OperationResult()
    {
        Message = string.Empty;
        IsSuccess = false;
    }


    public OperationResult Success(string message = "عملیات با موفقیت انجام شد.")
    {
        Message = message;
        IsSuccess = true;
        return this;
    }

    public OperationResult Faild(string message)
    {
        Message = message;
        IsSuccess = false;
        return this;
    }

}
