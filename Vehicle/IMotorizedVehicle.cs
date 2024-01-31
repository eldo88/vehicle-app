namespace vehicle_app;

public interface IMotorizedVehicle
{
    public string EngineType {get; set;}
    public decimal MPG {get; set;}
    public decimal Range {get; set;}
    public decimal FuelCapacity {get; set;} 
}