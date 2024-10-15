namespace vehicle_app;

public class LoadVehicleStats
{
    private readonly IVehicleRepository<Car> _carRepo = VehicleRepositoryFactory.BuildCarRepo();
    private readonly IVehicleRepository<Truck> _truckRepo = VehicleRepositoryFactory.BuildTruckRepo();
    private readonly IVehicleRepository<Suv> _suvRepo = VehicleRepositoryFactory.BuildSuvRepo();

    public List<VehicleStats> GetVehicleStats()
    {
        var data = new List<VehicleStats>();
        var carData = _carRepo.GetVehicles();

        foreach (var car in carData)
        {
            var carStats = new VehicleStats(car);
            data.Add(carStats);
        }

        var truckData = _truckRepo.GetVehicles();

        foreach (var truck in truckData)
        {
            var truckStats = new VehicleStats(truck);
            data.Add(truckStats);
        }

        var suvData = _suvRepo.GetVehicles();

        foreach (var suv in suvData)
        {
            var suvStats = new VehicleStats(suv);
            data.Add(suvStats);
        }

        return data;
    }
}