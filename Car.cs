
using System.Diagnostics.Contracts;

namespace vehicle_app;

public sealed class Car : Vehicle
{
    // public int? fuelCapacity = 18;

    public Car(string color, int capacity, string make, string model, int year, VehicleType vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType, engineType, mpg)
    {

    }

    public override Dictionary<string, decimal> Drive()
    {
        return base.Drive();
    }

    public override string ToString() => $"Make: {Make} Model: {Model} Year: {Year} Type: {VehicleType} Engine Type: {EngineType} Range: {Range}";

}