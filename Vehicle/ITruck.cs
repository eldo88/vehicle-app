namespace vehicle_app;

public interface ITruck : IMotorizedVehicle
{
    public bool? IsFourWheelDrive {get; set;}
    public decimal? BedLength {get; set;}
    public int? PayLoadCapacity {get; set;}
    public int? TowingCapacity {get; set;}
    public bool? IsDully {get; set;}
}
