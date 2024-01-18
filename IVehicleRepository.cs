namespace vehicle_app;

internal interface IVehicleRepository<T> where T : Vehicle
{

    public T GetVehicle();

    public void SaveVehicle(T vehicle);
    
}