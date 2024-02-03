namespace vehicle_app;

public static class MenuDataFactory
{
    public static VehicleColor CreateVehicleColor()
    {
        return new VehicleColor();
    }

    public static VehicleEngine CreateVehicleEngine()
    {
        return new VehicleEngine();
    }

    public static VehicleMake CreateVehicleMake()
    {
        return new VehicleMake();
    }

    public static VehicleModel CreateVehicleModel()
    {
        return new VehicleModel();
    }

    public static VehicleType CreateVehicleType()
    {
        return new VehicleType();
    }
}
