public class AppResult
{
    public bool Success { get; set; }
    public string? Code { get; set; }
    public string? Message { get; set; }

    public static AppResult Fail(string message, string code) => new AppResult
    {
        Success = false,
        Message = message,
        Code = code
    };
}
