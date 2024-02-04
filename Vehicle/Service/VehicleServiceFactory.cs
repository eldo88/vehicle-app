namespace vehicle_app;

public class VehicleServiceFactory
{
    public static IVehicleService CreateVehicleService()
    {
        return new VehicleService();
    }
}
