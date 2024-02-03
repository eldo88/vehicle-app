namespace vehicle_app;

public interface IVehicleModel
{
    Dictionary<string, List<string>> VehicleModelDict {get; set;}
    string GetVehicleModelByIdx(string vehicleMakeKey, int idx);
}
