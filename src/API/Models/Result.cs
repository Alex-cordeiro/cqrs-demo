namespace CQRS.Demo.API.Models;

public class Result
{

    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;
    public string Error { get; private set; }

    public Result()
    {
        
    }
    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, string.Empty);
    public static Result Failure(string error) => new Result(false, error);
    public static Result<T> Success<T>(T value) => new Result<T>(value, true, string.Empty);
    public static Result<T> Failure<T>(string error) => new Result<T>(default, false, error);
    public void Ensure(bool condition)
    {
        IsSuccess = condition;
    }
}

public class Result<T> : Result
{
    public T? Value { get; private set; }

    internal Result(T? value, bool isSuccess, string error) : base(isSuccess, error)
    {
        Value = value;
    }
}