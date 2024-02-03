namespace vehicle_app;

public class GasEngine : IGasEngine
{
    public int RecommendedFuelOctane { get; set; }
    public bool HasSuperCharger { get; set; }
    public int NumberOfCylinders { get; set; }
    public bool HasTurbo { get; set; }
    public string FuelType { get; set; } = "";
    public int HorsePower { get; set; }
    public int Torque { get; set; }
}
