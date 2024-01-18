namespace vehicle_app;

internal interface IVehicleRepository<T> where T : Vehicle
{

    public List<T> GetVehicles();

    public void SaveVehicle(T vehicle);
    
}