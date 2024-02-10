namespace vehicle_app;

public interface IFuelBurningEngine : IEngine
{
    bool HasTurbo { get; set; }
}
