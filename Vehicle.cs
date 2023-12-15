namespace vehicle_app;

public abstract class Vehicle
{

    public Vehicle(string color, int capacity, string make, string model, int year, VehicleType vehicleType, string engineType, int mpg)
    {
        if (string.IsNullOrWhiteSpace(color))
            {throw new ArgumentException("The color is required.");}
        Color = color;

        Capacity = capacity;

        if (string.IsNullOrWhiteSpace(make))
            {throw new ArgumentException("The vehicle make is required.");}
        Make = make;

        if (string.IsNullOrWhiteSpace(model))
            {throw new ArgumentException("The vehicle model is required.");}
        Model = model;

        Year = year;

        VehicleType = vehicleType;

        if (string.IsNullOrWhiteSpace(engineType))
            {throw new ArgumentException("Engine type is required");}
        EngineType = engineType;

        if (engineType != "Electric")
        {
            MPG = mpg;
            FuelCapacity = 20;
            Range = FuelCapacity * MPG;
        }
        else
        {
            Range = 350;
            FuelCapacity = 0;
            MPG = 0;
        }
    }

    public string Color {get; set;}
    public int? Capacity {get; set;}
    public string Make {get; set;}
    public string Model {get; set;}
    public int? Year {get; set;}
    public VehicleType VehicleType {get;}
    public string EngineType {get; set;}
    public decimal MPG {get; set;}
    public decimal Range {get; set;}
    public decimal FuelCapacity {get; set;} 


    public virtual Dictionary<string, decimal> Drive(decimal tripLength)
    {
        Dictionary<string, decimal> tripDetails = new Dictionary<string, decimal>();
        

        if (MPG != 0)
        {
            decimal totalGallonsOfFuelNeeded = (decimal)tripLength / (decimal)MPG * 2;
            decimal numberOfTanksOfGasNeeded = totalGallonsOfFuelNeeded / FuelCapacity * 2;
            tripDetails["totalGallonsOfFuelNeeded"] = totalGallonsOfFuelNeeded;
            tripDetails["numberOfTanksOfGasNeeded"] = numberOfTanksOfGasNeeded;
            tripDetails["vehicleMpg"] = MPG;
        }
        else
        {
            decimal numberOfChargesNeeded = (decimal)tripLength / (decimal)Range * 2;
            tripDetails["numberOfChargesNeeded"] = numberOfChargesNeeded;
        }

        tripDetails["vehicleRange"] = Range;

        return tripDetails;
    }

    public virtual void PrintTripDetails(Dictionary<string, decimal> tripDetails)
    {
            foreach (var item in tripDetails)
            {
                Console.WriteLine("{0:0.00} {1:0.00}", item.Key, item.Value);
            }
    }
}