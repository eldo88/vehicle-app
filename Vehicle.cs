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

        if (year <= 1990 && year >= DateTime.Now.Year + 1)
            {throw new ArgumentException("The vehicle year is invalid");}
        Year = year;

        if (string.IsNullOrWhiteSpace(vehicleType))
            {throw new ArgumentException("The vehicle type is required");}
        VehicleType = (VehicleType) Enum.Parse(typeof(VehicleType), vehicleType);

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

        Guid = Guid.NewGuid(); // TODO: add as property in ctor
    }

    public Guid Guid {get;} // move to concrete classes?
    public string Color {get; set;}
    public int Capacity {get; set;}
    public string Make {get; set;}
    public string Model {get; set;}
    public int Year {get; set;}
    public VehicleType VehicleType {get; set;}
    public string EngineType {get; set;}
    public decimal MPG {get; set;}
    public decimal Range {get; set;}
    public decimal FuelCapacity {get; set;} 

    public List<string> FormatDataForSavingToFile()
    {
        var guid = Guid.ToString();
        var capacity = Convert.ToString(Capacity);
        var year = Convert.ToString(Year);
        var vehicleType = Enum.GetName(typeof(VehicleType), VehicleType);
        var mpg = Convert.ToString(MPG);
        var range = Convert.ToString(Range);
        var fuelCapacity = Convert.ToString(FuelCapacity);

        #pragma warning disable CS8601 // Possible null reference assignment.
        List<string> data = [guid, Color, capacity, Make, Model, year, vehicleType, EngineType, mpg, range, fuelCapacity];
        #pragma warning restore CS8601 // Possible null reference assignment.
        return data;
    }

    public virtual List<(string, decimal)> Drive(decimal tripLength)
    {
        List<(string, decimal)> tripDetail = [];
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

    public virtual void PrintDriveDetails(List<(string, decimal)> tripDetails)
    {
            Console.WriteLine("\nThe details of your drive are:\n");
            foreach (var item in tripDetails)
            {
                Console.WriteLine("{0}: {1:0.00}", item.Item1, item.Item2);
            }
    }
}