namespace vehicle_app;

public interface IVehicleEngine
{
    List<string> EngineList {get; set;} 
    string GetEngineTypeByIdx(int idx);
}
