namespace vehicle_app;

public interface IGasEngine : IFuelBurningEngine
{
    int RecommendedFuelOctane { get; set; }
    bool HasSuperCharger { get; set; }
}
