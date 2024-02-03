namespace vehicle_app;

public interface IVehicleColor
{
    List<string> ColorList{get; set;}
    string GetVehicleColorByIdx(int idx);
}
