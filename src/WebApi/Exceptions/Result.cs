public class Result
{
    public bool Success { get; set; }
    public string? Code { get; set; }
    public string? Message { get; set; }

    public static Result Fail(string message, string code) => new Result
    {
        Success = false,
        Message = message,
        Code = code
    };
}
