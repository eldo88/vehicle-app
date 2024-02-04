namespace vehicle_app;

public class VehicleEvent : EventArgs
{
    public IVehicle? Vehicle { get; set; }
}
