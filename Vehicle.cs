namespace vehicle_app;

public abstract class Vehicle : Drive
{

    public Vehicle(string color, int capacity, string make, string model, int year, VehicleType vehicleType)
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
    }

    public string? Color {get; set;}
    public int? Capacity {get; set;}
    public string? Make {get; set;}
    public string? Model {get; set;}
    public int? Year {get; set;}
    public VehicleType VehicleType {get;}


    public void Drive()
    {

    }
}