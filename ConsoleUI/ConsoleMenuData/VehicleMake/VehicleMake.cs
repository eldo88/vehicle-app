namespace vehicle_app;

public class VehicleMake : IVehicleMake
{
    public VehicleMake()
    {
        VehicleMakeList = FileOperations.ReadDataFromFile("./data/vehicle-data/vehicle-make-data.csv");
    }
    public List<string> VehicleMakeList {get; set;}

    public string GetVehicleMakeByIdx(int idx)
    {
        return VehicleMakeList[idx];
    }
}