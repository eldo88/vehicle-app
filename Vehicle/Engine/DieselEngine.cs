namespace vehicle_app;

public class DieselEngine : IDieselEngine
{
    public int NumberOfCylinders { get; set; }
    public bool HasTurbo { get; set; }
    public string FuelType { get; set; } = "";
    public int HorsePower { get; set; }
    public int Torque { get; set; }
}
