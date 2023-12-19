
namespace vehicle_app;

public class Suv : Vehicle
{
    public Suv(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType, engineType, mpg)
    {
    }

    public override Dictionary<string, decimal> Drive(decimal tripLength)
    {
        return base.Drive(tripLength);
    }

    public override void PrintDriveDetails(Dictionary<string, decimal> tripDetails)
    {
        base.PrintDriveDetails(tripDetails);
    }

    public override string ToString() => $"\nThe details of your vehicle are:\n\nMake: {Make}\nModel: {Model}\nYear: {Year}\nType: {VehicleType}\nEngine Type: {EngineType}\nRange: {Range}\n";

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}