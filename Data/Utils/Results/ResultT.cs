namespace Data.Utils.Results;

public class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T Value { get; }
    public string ErrorMessage { get; }

    protected Result(T value, bool isSuccess, string errorMessage)
    {
        Value = value;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static Result<T> Ok(T value) => new Result<T>(value, true, string.Empty);
    public static Result<T> Fail(string errorMessage) => new Result<T>(default!, false, errorMessage);
}
