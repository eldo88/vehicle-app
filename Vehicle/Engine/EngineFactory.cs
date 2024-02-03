namespace vehicle_app;

public class EngineFactory
{
    public static IGasEngine CreateGasEngine(int numberOfCylinders, bool hasTurbo)
    {
        return new GasEngine(numberOfCylinders, hasTurbo);
    }

    public static IElectricMotor CreateElectricMotor()
    {
        return new ElectricMotor();
    }

    public static IDieselEngine CreateDieselEngine(int numberOfCylinders)
    {
        return new DieselEngine(numberOfCylinders);
    }
}
