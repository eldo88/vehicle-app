
namespace vehicle_app;

public class Suv : MotorizedVehicle
{
    public Suv() {}

    public Suv(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg) : base(color, capacity, make, model, year, vehicleType, engineType, mpg)
    {
    }

    public bool? IsFourWheelDrive {get; set;}
    public int? TowingCapacity {get; set;}
    public int? CargoSpace {get; set;}

    public override string ToString() => $"\nThe details of your vehicle are:\n\nMake: {Make}\nModel: {Model}\nYear: {Year}\nType: {VehicleTypeEnum}\nColor: {Color}\nEngine Type: {EngineType}\nRange: {Range}\n";

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}