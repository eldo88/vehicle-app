namespace vehicle_app;

public interface IVehicleMake
{
    List<string> VehicleMakeList {get; set;}
    string GetVehicleMakeByIdx(int idx);
}
