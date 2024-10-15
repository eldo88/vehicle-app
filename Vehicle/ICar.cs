namespace vehicle_app;

public interface ICar : IMotorizedVehicle
{
    public int? NumDoors {get; set;}
    public bool? IsConvertible {get; set;}
}
