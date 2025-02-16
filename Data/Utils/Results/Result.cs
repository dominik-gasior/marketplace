namespace Data.Utils.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string ErrorMessage { get; }

    protected Result(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static Result Ok() => new Result(true, string.Empty);
    public static Result Fail(string errorMessage) => new Result(false, errorMessage);
}