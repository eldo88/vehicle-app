namespace vehicle_app;

public class DieselEngine : IDieselEngine
{
    public DieselEngine(int numberOfCylinders)
    {
        NumberOfCylinders = numberOfCylinders;

        switch (NumberOfCylinders)
        {
            case 4:
                HorsePower = 250;
                Torque = 450;
                break;
            case 6:
                HorsePower = 350;
                Torque = 550;
                break;
            case 8:
                HorsePower = 400;
                Torque = 650;
                break;
            default:
                HorsePower = 250;
                Torque = 450;
                break;
        }
    }

    public int NumberOfCylinders { get; set; }
    public bool HasTurbo { get; set; } = true;
    public string FuelType { get; set; } = "Diesel";
    public int HorsePower { get; set; }
    public int Torque { get; set; }
}
