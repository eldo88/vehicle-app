namespace vehicle_app;

public interface IEngine
{
    int HorsePower { get; set; } 
    int Torque { get; set; }
    string FuelType { get; set; }
    int NumberOfCylinders { get; set; }
}
