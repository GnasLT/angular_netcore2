
namespace MyAPI.Application.DTO.Response;

public class Result<T>
{
    public bool Success { get; set; }

    public required string Message { get; set; }

    public short StatusCode{ get; set; }

    public T? Data { get; set; }

    public static Task<Result<T>> SuccessResult(T? data, string message)
    {
        return Task.FromResult(new Result<T>
        {
            Success = true,
            Message = message,
            Data = data
        });
    }

    public static Task<Result<T>> FailureResult(string message)
    {
        return Task.FromResult(new Result<T>
        {
            Success = false,
            Message = message,
            Data = default
        });
    }
}
    