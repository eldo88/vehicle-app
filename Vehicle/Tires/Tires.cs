using System.Text.Json.Serialization;

namespace vehicle_app;

public class Tires : ITires
{
    public string BrandName { get; set; } = "";
    public string Size { get; set; } = "";
    public decimal Radius { get; set; }

    public Tires(string vehicleType)
    {
        switch (vehicleType)
        {
            case "Car": 
                BrandName = "Michelin";
                Size = "245/65-17";
                Radius = 17;
                break;
            case "Truck":
                BrandName = "BF Goodrich";
                Size = "285/65-18";
                Radius = 18;
                break;
            case "SUV":
                BrandName = "Goodyear";
                Size = "275/65-19";
                Radius = 19;
                break;
            default: 
                BrandName = "Michelin";
                Size = "245/65-17";
                Radius = 17;
                break;
        }
    }

    [JsonConstructor] 
    public Tires(string brandName, string size, decimal radius)
    {
        BrandName = brandName;
        Size = size;
        Radius = radius;
    }
}