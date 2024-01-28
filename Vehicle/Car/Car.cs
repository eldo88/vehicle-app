namespace vehicle_app;

public class Car : Vehicle
{
   public Car(){}
    public Car(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg)
    : base(color, capacity, make, model, year, vehicleType, engineType, mpg)
    {/*empty for now*/}

    public int? NumDoors {get; set;}
    public bool? IsConvertible {get; set;}

    public override List<(string, decimal)> Drive(decimal tripLength)
    {
        return base.Drive(tripLength);
    }

    public override void PrintDriveDetails(List<(string, decimal)> tripDetails)
    {
        base.PrintDriveDetails(tripDetails);
    }

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