using System.Security.Cryptography;

namespace vehicle_app;

public class GasEngine : IGasEngine
{
    public GasEngine() {}
    public GasEngine(int numberOfCylinders, bool hasTurbo)
    {
        NumberOfCylinders = numberOfCylinders;
        HasTurbo = hasTurbo;

        if (HasTurbo)
        {
            RecommendedFuelOctane = 91;
            switch (NumberOfCylinders)
            {
                case 4:
                    HorsePower = 300;
                    Torque = 355;
                    break;
                case 6:
                    HorsePower = 380;
                    Torque = 440;
                    break;
                case 8: 
                    HorsePower = 450;
                    Torque = 520;
                    break;
                default:
                    HorsePower = 300;
                    Torque = 355;
                    break;
            }
        }
        else
        {
            RecommendedFuelOctane = 85;
            switch (NumberOfCylinders)
            {
                case 4:
                    HorsePower = 250;
                    Torque = 260;
                    break;
                case 6:
                    HorsePower = 330;
                    Torque = 360;
                    break;
                case 8: 
                    HorsePower = 400;
                    Torque = 455;
                    break;
                default:
                    HorsePower = 250;
                    Torque = 260;
                    break;
            }
        }
    }

    public int RecommendedFuelOctane { get; set; }
    public bool HasSuperCharger { get; set; } = false;
    public int NumberOfCylinders { get; set; }
    public bool HasTurbo { get; set; }
    public string FuelType { get; set; } = "Gas";
    public int HorsePower { get; set; }
    public int Torque { get; set; }

    public int SetHorsePower(int numberOfCylinders, bool hasTurbo)
    {
        if (hasTurbo)
        {
            return numberOfCylinders switch
            {
                4 => 300,
                6 => 380,
                8 => 450,
                _ => 300,
            };
        } else
        {
            return numberOfCylinders switch
            {
                4 => 250,
                6 => 330,
                8 => 400,
                _ => 250
            };
        }
    }
}
