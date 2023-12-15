
namespace vehicle_app;

public class Suv : Vehicle
{
    public Suv(string color, int capacity, string make, string model, int year, VehicleType vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType, engineType, mpg)
    {
    }

    public override Dictionary<string, decimal> Drive(decimal tripLength)
    {
        return base.Drive(tripLength);
    }

    public override void PrintTripDetails(Dictionary<string, decimal> tripDetails)
    {
        base.PrintTripDetails(tripDetails);
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