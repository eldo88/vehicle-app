namespace vehicle_app;

public interface IMotorizedVehicle : IVehicle
{
    public string EngineType {get; set;}
    public decimal Mpg {get; set;}
    public decimal Range {get; set;}
    public decimal FuelCapacity {get; set;} 
    IEngine? Engine { get; set; }
}