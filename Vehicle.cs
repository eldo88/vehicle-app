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
        }
    }

    public string? Color {get; set;}
    public int? Capacity {get; set;}
    public string Make {get; set;}
    public string Model {get; set;}
    public int? Year {get; set;}
    public VehicleType VehicleType {get;}
    public string EngineType {get; set;}
    public decimal? MPG {get; set;}
    public decimal? Range {get; set;}
    public decimal? FuelCapacity {get; set;} 


    public virtual Dictionary<string, decimal> Drive()
    {
        Dictionary<string, decimal> tripDetails = new Dictionary<string, decimal>();

        return tripDetails;
    }
}