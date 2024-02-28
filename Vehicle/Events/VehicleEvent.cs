namespace vehicle_app;

public class VehicleEvent : EventArgs
{
    public VehicleEvent(IVehicle vehicle)
    {
        Vehicle = vehicle;
    }
    
    public IVehicle Vehicle { get; set; }
}
