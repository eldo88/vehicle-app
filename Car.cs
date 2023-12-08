namespace vehicle_app;

public sealed class Car : Vehicle
{
    public Car(string color, int capacity, string make, string model, int year, VehicleType vehicleType) : base(color, capacity, make, model, year, vehicleType)
    {
    }

    public override string ToString() => $"Make: {Make} Model: {Model} Year: {Year}";

}