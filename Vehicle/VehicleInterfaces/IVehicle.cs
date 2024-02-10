namespace vehicle_app;

public interface IVehicle
{
    public Guid Guid {get;}
    public string Color {get; set;}
    public int Capacity {get; set;}
    public string Make {get; set;}
    public string Model {get; set;}
    public int Year {get; set;}
    public VehicleTypeEnum VehicleTypeEnum {get; set;}
}