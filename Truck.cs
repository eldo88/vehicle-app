
namespace vehicle_app;

public class Truck : Vehicle
{
    public Truck(string color, int capacity, string make, string model, int year, VehicleType vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType, engineType, mpg)
    {
    }

    public override Dictionary<string, decimal> Drive()
    {
        return base.Drive();
    }

    public override string ToString() => $" Make: {Make}\n Model: {Model}\n Year: {Year}\n Type: {VehicleType}\n Engine Type: {EngineType}\n Range: {Range}\n";

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}