namespace vehicle_app;

public interface IVehicleRepository<T> where T : IVehicle
{
    public List<T> GetVehicles();
    public IEnumerable<T> GetVehicleByMake(string make);
    public List<T> GetVehicleByModel(string model);
    public T GetVehicleById(Guid id);
    public void SaveVehicle(T vehicle);
    
}