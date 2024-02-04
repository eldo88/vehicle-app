namespace vehicle_app;

public class Logger : ILogger
{
    public string Message { get; set; } = "";

    public static void LogTExceptionToFile(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
