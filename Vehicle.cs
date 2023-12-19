namespace vehicle_app;

public abstract class Vehicle
{

    public Vehicle(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg)
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

        if (string.IsNullOrWhiteSpace(vehicleType))
            {throw new ArgumentException("The vehicle type is required");}
        switch (vehicleType)
        {
            case "Car":
                VehicleType = VehicleType.Car;
                break;
            case "Truck":
                VehicleType = VehicleType.Truck;
                break;
            case "SUV":
                VehicleType = VehicleType.SUV;
                break;
        }

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
        
        if (tripLength == 0)
        {
            tripDetails.Add("Error", 0);
            return tripDetails;
        }

        tripDetails.Add("Drive length", tripLength * 2);

        if (MPG != 0)
        {
            decimal totalGallonsOfFuelNeeded = (decimal)tripLength / (decimal)MPG * 2;
            decimal numberOfTanksOfGasNeeded = totalGallonsOfFuelNeeded / FuelCapacity * 2;
            tripDetails.Add("Total Gallons Of Fuel Needed", totalGallonsOfFuelNeeded);
            tripDetails.Add("Number Of Tanks Of Gas Needed",numberOfTanksOfGasNeeded);
            tripDetails.Add("Vehicle Mpg", MPG);
        }
        else
        {
            decimal numberOfChargesNeeded = (decimal)tripLength / (decimal)Range * 2;
            tripDetails["Number Of Charges Needed"] = numberOfChargesNeeded;
        }

        tripDetails.Add("Vehicle Range", Range);

        return tripDetails;
    }

    public virtual void PrintDriveDetails(Dictionary<string, decimal> tripDetails)
    {
            Console.WriteLine("\nThe details of your drive are:\n");
            foreach (var item in tripDetails)
            {
                Console.WriteLine("{0} {1:0.00}", item.Key, item.Value);
            }
    }
}