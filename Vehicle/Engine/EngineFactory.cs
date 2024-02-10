namespace vehicle_app;

public class EngineFactory
{
    public static IEngine Build(string fuelType, int numberOfCylinders, bool hasTurbo = false)
    {
        return fuelType switch 
        {
            "Gas" => new GasEngine(numberOfCylinders, hasTurbo),
            "Diesel" => new DieselEngine(numberOfCylinders),
            "Electric" => new ElectricMotor(),
            _ => new GasEngine(numberOfCylinders, hasTurbo)
        };
    }
}
