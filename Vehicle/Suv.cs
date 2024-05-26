
namespace vehicle_app;

public class Suv : ISuv
{
    public Suv() {}

    public Suv(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg, int currentMileage, IEngine engine, IWheels wheels, ITires tires)
    {
        if (string.IsNullOrWhiteSpace(color))
            {throw new ArgumentException("Color is required");}
        Color = color;

        Capacity = capacity;

        if (string.IsNullOrWhiteSpace(make))
            {throw new ArgumentException("Make is required");}
        Make = make;

        if (string.IsNullOrWhiteSpace(model))
            {throw new ArgumentException("Model is required");}
        Model = model;

        Year = year;

        if (string.IsNullOrWhiteSpace(vehicleType))
            {throw new ArgumentException("Make is required");}
        VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), vehicleType);

        if (string.IsNullOrWhiteSpace(engineType))
            {throw new ArgumentException("Engine type is required");}
        EngineType = engineType;

        if (engineType == "Electric")
        {
            Range = 350;
            FuelCapacity = 0;
            MPG = 0;
        }
        else
        {
            MPG = mpg;
            FuelCapacity = 20;
            Range = FuelCapacity * MPG;
        }

        Guid = Guid.NewGuid(); 

        CurrentMileage = currentMileage;

        Engine = engine;

        Wheels = wheels;

        Tires = tires;
    }

    public bool? IsFourWheelDrive {get; set;} = false;
    public int? TowingCapacity {get; set;} = 5000;
    public int? CargoSpace {get; set;} = 15;

    public string EngineType { get; set; } = "";
    public decimal MPG { get; set; }
    public decimal Range { get; set; }
    public decimal FuelCapacity { get; set; }

    public Guid Guid {get; set;}

    public string Color { get; set; } = "";
    public int Capacity { get; set; }
    public string Make { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public VehicleTypeEnum VehicleTypeEnum { get; set; }
    public IWheels? Wheels { get; set; }
    public ITires? Tires { get; set;  }
    public int CurrentMileage { get; set; }
    public IEngine? Engine {get; set;}

    List<(string, decimal)> IMotorizedVehicle.Drive(decimal tripLength)
    {
        List<(string, decimal)> tripDetail = new();
        (string, decimal) message;

        if (tripLength <= 0)
        {
            message = ("Error", 0);
            tripDetail.Add(message);
        }

        message = ("Drive length", tripLength);
        tripDetail.Add(message);

        if (MPG == 0)
        {
            decimal numberOfChargesNeeded = (decimal)tripLength / (decimal)Range;
            message = ("Number Of Charges Needed", numberOfChargesNeeded);
            tripDetail.Add(message);
        }
        else
        {
            decimal totalGallonsOfFuelNeeded = (decimal)tripLength / (decimal)MPG;
            decimal numberOfTanksOfGasNeeded = totalGallonsOfFuelNeeded / FuelCapacity;
            message = ("Total Gallons Of Fuel Needed", totalGallonsOfFuelNeeded);
            tripDetail.Add(message);
            message = ("Number Of Tanks Of Gas Needed",numberOfTanksOfGasNeeded);
            tripDetail.Add(message);
            message = ("Vehicle Mpg", MPG);
            tripDetail.Add(message);
        }

        message = ("Vehicle Range", Range);
        tripDetail.Add(message);

        return tripDetail;
    }

    public override string ToString() => $"\nThe details of your vehicle are:\n\nMake: {Make}\nModel: {Model}\nYear: {Year}\nType: {VehicleTypeEnum}\nColor: {Color}\nEngine Type: {EngineType}\nRange: {Range}\n";

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}