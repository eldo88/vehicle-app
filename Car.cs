
using System.Diagnostics.Contracts;

namespace vehicle_app;

public sealed class Car : Vehicle
{
    public string EngineType;
    public int? MPG;
    public int? Range;
    public int? fuelCapacity = 18;
    public Car(string color, int capacity, string make, string model, int year, VehicleType vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType)
    {
        if (string.IsNullOrWhiteSpace(engineType))
            {throw new ArgumentException("Engine type is required");}
        EngineType = engineType;

        if (engineType != "Electric")
        {
            MPG = mpg;
            Range = fuelCapacity * MPG;
        }
        else
        {
            Range = 350;
            fuelCapacity = 0;
        }
    }

    public override Dictionary<string, decimal> Drive()
    {
        return base.Drive();
    }

    public override string ToString() => $"Make: {Make} Model: {Model} Year: {Year} Type: {VehicleType} Engine Type: {EngineType} Range: {Range}";

}