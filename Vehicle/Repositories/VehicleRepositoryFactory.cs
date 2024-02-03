namespace vehicle_app;

public static class VehicleRepositoryFactory
{
    public static IVehicleRepository<Car> BuildCarRepo()
    {
        return new CarRepository();
    }

    public static IVehicleRepository<Truck> BuildTruckRepo()
    {
        return new TruckRepository();
    }

    public static IVehicleRepository<Suv> BuildSuvRepo()
    {
        return new SuvRepository();
    }
}
