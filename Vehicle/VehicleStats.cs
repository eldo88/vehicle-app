namespace vehicle_app;

public class VehicleStats
{
    public int Mileage;
    public int Year;
    public string Make;
    public string Model;
    public string Color;

    public VehicleStats(IVehicle vehicle)
    {
        Mileage = vehicle.CurrentMileage;
        Year = vehicle.Year;
        Make = vehicle.Make;
        Model = vehicle.Model;
        Color = vehicle.Color;
    }
}