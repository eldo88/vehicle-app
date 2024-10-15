namespace vehicle_app;

public interface ISuv : IMotorizedVehicle
{
    public bool? IsFourWheelDrive {get; set;}
    public int? TowingCapacity {get; set;}
    public int? CargoSpace {get; set;}
}
