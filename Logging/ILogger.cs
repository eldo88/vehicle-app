namespace vehicle_app;

public interface ILogger
{
    string Message { get; set; }
    abstract static void LogTExceptionToFile(Exception ex);
}
