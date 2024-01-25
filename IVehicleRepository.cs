namespace vehicle_app;

internal interface IVehicleRepository<T> where T : Vehicle
{

    public List<T> GetVehicles();
    public List<T> GetVehicleByMake(string make);
    public List<T> GetVehicleByModel(string model);
    public T GetVehicleById(Guid id);
    public void SaveVehicle(T vehicle);
    
}