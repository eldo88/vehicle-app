namespace vehicle_app;

public class ElectricMotor : IElectricMotor
{
    public int HorsePower { get; set; } = 400;
    public int Torque { get; set; } = 350;
}
