namespace vehicle_app;

class CarCreator : VehicleCreator
{
    public override Vehicle VehicleFactory(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg)
    {
        return new Car(color, capacity, make, model, year, vehicleType, engineType, mpg);
    }
}