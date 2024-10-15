namespace vehicle_app;

public static class VehicleExtensions
{
    public static string DetailedMessage(this Exception exception) // maybe make custom exception extensions class
    {
        return $"An error occured at {DateTime.Now} \n Here are the details:" +
               $"\n {exception.Message}" +
               $"\n {exception.StackTrace}";
    }

    public static string GetVehicleMakeAndModel(this IMotorizedVehicle vehicle)
    {
        return $"{vehicle.Make} {vehicle.Model}";
    }
}