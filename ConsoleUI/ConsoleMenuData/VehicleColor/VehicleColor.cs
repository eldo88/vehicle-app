namespace vehicle_app;

public class VehicleColor : IVehicleColor
{
    public VehicleColor()
    {
        ColorList = FileOperations.ReadDataFromFile("./data/vehicle-data/vehicle-color-data.csv");
    }
    public List<string> ColorList{get; set;}

    public string GetVehicleColorByIdx(int idx)
    {
        return ColorList[idx];
    }
}