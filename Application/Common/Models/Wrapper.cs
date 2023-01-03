namespace Application.Common.Models;

public class Wrapper<T>
{
    public Wrapper(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public Wrapper(bool isSuccess, T data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }

    public Wrapper(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public Wrapper(bool isSuccess, string message, T data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }

    public bool IsSuccess { get; }
    public string? Message { get; }
    public T? Data { get; }
}

public class Wrapper
{
    public Wrapper(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public Wrapper(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; }
    public string? Message { get; }
}