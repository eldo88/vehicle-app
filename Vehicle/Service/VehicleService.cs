
namespace vehicle_app;

public class VehicleService : IVehicleService
{
    public void OnVehicleSaved(object? source, VehicleEvent vehicleEvent)
    {
        if (vehicleEvent is not null)
        {
            switch (vehicleEvent.Vehicle?.VehicleTypeEnum)
            {
                case VehicleTypeEnum.Truck:
                var truckRepository = VehicleRepositoryFactory.BuildTruckRepo();
                var truck = (Truck)vehicleEvent.Vehicle;
                truckRepository.SaveVehicle(truck);
                break;
                case VehicleTypeEnum.Car:
                var carRepository = VehicleRepositoryFactory.BuildCarRepo();
                var car = (Car)vehicleEvent.Vehicle;
                carRepository.SaveVehicle(car);
                break;
                case VehicleTypeEnum.SUV:
                var suvRepository = VehicleRepositoryFactory.BuildSuvRepo();
                var suv = (Suv)vehicleEvent.Vehicle;
                suvRepository.SaveVehicle(suv);
                break;
                default:
                break;
            }
        }
    }
}
