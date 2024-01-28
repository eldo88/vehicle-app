namespace vehicle_app;

public class VehicleType
{
    public VehicleType()
    {
        VehicleTypeList = FileOperations.ReadDataFromFile("./data/vehicle-data/vehicle-type-data.csv");
    }
    public List<string> VehicleTypeList {get; set;}

    public string GetVehicleTypeByIdx(int idx)
    {
        return VehicleTypeList[idx];
    }
}