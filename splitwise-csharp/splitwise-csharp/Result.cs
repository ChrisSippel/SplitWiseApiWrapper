namespace splitwise_csharp;

public sealed class Result<T>
{
    private Result(T value)
    {
        Value = value;
        ErrorMessage = null;
        IsSuccessful = true;
    }

    private Result(string errorMessage)
    {
        Value = default;
        ErrorMessage = errorMessage;
        IsSuccessful = false;
    }

    public T? Value { get; }

    public string? ErrorMessage { get; }

    public bool IsSuccessful { get; }

    public static Result<T> Success(T value) =>
        new Result<T>(value);

    public static Result<T> Failure(string errorMessage) =>
        new Result<T>(errorMessage);
}