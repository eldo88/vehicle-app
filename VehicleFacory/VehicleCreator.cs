namespace vehicle_app;

public abstract class VehicleCreator
{
    public abstract Vehicle VehicleFactory(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg);
}