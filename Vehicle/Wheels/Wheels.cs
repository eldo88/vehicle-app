using System.Text.Json.Serialization;

namespace vehicle_app.Vehicle.Wheels;

public class Wheels : IWheels
{
    public string WheelBrand { get; set; }
    public decimal Radius { get; set; }

    public Wheels(string wheelBrand, string vehicleType)
    {
        WheelBrand = wheelBrand;
        Radius = vehicleType switch
        {
            "Car" => 17,
            "Truck" => 18,
            "SUV" => 19,
            _ => 18
        };
    }

    [JsonConstructor]
    public Wheels(string wheelBrand, decimal radius)
    {
        WheelBrand = wheelBrand;
        Radius = radius;
    }
}