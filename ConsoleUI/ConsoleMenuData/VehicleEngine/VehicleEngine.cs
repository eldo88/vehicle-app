namespace vehicle_app;

public class VehicleEngine : IVehicleEngine
{
    public VehicleEngine()
    {
        EngineList = FileOperations.ReadDataFromFile("./data/vehicle-data/engine-data.csv");
    }

    public List<string> EngineList {get; set;}

    public string GetEngineTypeByIdx(int idx)
    {
        return EngineList[idx];
    }
}