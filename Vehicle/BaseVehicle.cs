namespace vehicle_app;

public abstract class BaseVehicle : IVehicle
{
    public BaseVehicle(){}

    public BaseVehicle(string color, int capacity, string make, string model, int year, string vehicleType, string engineType, int mpg)
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
        VehicleTypeEnum = (VehicleTypeEnum) Enum.Parse(typeof(VehicleTypeEnum), vehicleType);

        Guid = Guid.NewGuid(); // TODO: add as property in ctor
    }

    public Guid Guid {get;} // move to concrete classes?
    public string Color {get; set;} = "";
    public int Capacity {get; set;}
    public string Make {get; set;} = "";
    public string Model {get; set;} = "";
    public int Year {get; set;}
    public VehicleTypeEnum VehicleTypeEnum {get; set;}

    public List<string> FormatDataForSavingToFile() // move to utility class
    {
        var guid = Guid.ToString();
        var capacity = Convert.ToString(Capacity);
        var year = Convert.ToString(Year);
        var vehicleType = Enum.GetName(typeof(VehicleTypeEnum), VehicleTypeEnum);
        // var mpg = Convert.ToString(MPG);
        // var range = Convert.ToString(Range);
        // var fuelCapacity = Convert.ToString(FuelCapacity);
        List<string> data = [];

        if (vehicleType is not null)
        {
            data = [guid, Color, capacity, Make, Model, year, vehicleType, /*EngineType, mpg, range, fuelCapacity*/];
        }
        return data;
    }

}