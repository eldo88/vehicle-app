namespace vehicle_app;

public class Tires : ITires
{
    public string BrandName { get; set; } = "";
    public string Size { get; set; } = "";
    public decimal Radius { get; set; }
}