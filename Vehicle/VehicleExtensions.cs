namespace vehicle_app;

public static class VehicleExtensions
{
    public static string DetailedMessage(this Exception exception)
    {
        return $"An error occured at {DateTime.Now} \n Here are the details " +
               $"\n {exception.Message} +" +
               $"\n {exception.StackTrace}";
    }
}