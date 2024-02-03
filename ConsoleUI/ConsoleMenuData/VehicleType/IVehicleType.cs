namespace vehicle_app;

public interface IVehicleType
{
    List<string> VehicleTypeList {get; set;}
    string GetVehicleTypeByIdx(int idx);
}
