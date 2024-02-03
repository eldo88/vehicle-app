namespace vehicle_app;

public interface IFuelBurningEngine : IEngine
{
    int NumberOfCylinders { get; set; }
    bool HasTurbo { get; set; }
    string FuelType { get; set; }
}
