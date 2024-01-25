namespace vehicle_app;

public class VehicleEngine
{
    public VehicleEngine()
    {
        EngineList = FileOperations.ReadDataFromFile("./data/vehicle-data/engine-data.csv");
    }

    public List<string> EngineList {get; set;}
}