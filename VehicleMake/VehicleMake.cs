namespace vehicle_app;

public class VehicleMake
{
    public VehicleMake()
    {
        VehicleMakeList = FileOperations.ReadDataFromFile("./data/vehicle-data/vehicle-make-data.csv");
    }
    public List<string> VehicleMakeList {get; set;}
}