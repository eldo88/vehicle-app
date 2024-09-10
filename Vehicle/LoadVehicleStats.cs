namespace vehicle_app;

public class LoadVehicleStats
{
    private IVehicleRepository<Car> carRepo = VehicleRepositoryFactory.BuildCarRepo();
    private IVehicleRepository<Truck> truckRepo = VehicleRepositoryFactory.BuildTruckRepo();
    private IVehicleRepository<Suv> suvRepo = VehicleRepositoryFactory.BuildSuvRepo();

    public List<VehicleStats> GetVehicleStats()
    {
        var data = new List<VehicleStats>();
        var carData = carRepo.GetVehicles();

        foreach (var car in carData)
        {
            var carStats = new VehicleStats(car);
            data.Add(carStats);
        }

        var truckData = truckRepo.GetVehicles();

        foreach (var truck in truckData)
        {
            var truckStats = new VehicleStats(truck);
            data.Add(truckStats);
        }

        var suvData = suvRepo.GetVehicles();

        foreach (var suv in suvData)
        {
            var suvStats = new VehicleStats(suv);
            data.Add(suvStats);
        }

        return data;
    }
}