using System.Collections;

namespace vehicle_app;

public class SaveMenu
{
    public static void SaveVehicleMenu(IVehicle vehicle)
    {
        bool displayMenu = true;
        do
        {
            StandardUiMessages.MenuSeparator();
            StandardUiMessages.SaveVehicleMessage(vehicle);
            var choice = Console.ReadLine();

            if (char.TryParse(choice, out char result))
            {
                if (char.ToLower(result) == 'y')
                {
                    SaveVehicle(vehicle);
                    displayMenu = false;
                }
                else if (char.ToLower(result) == 'n')
                {
                    displayMenu = false;
                }
                else if (choice is not null)
                {
                    StandardUiMessages.InvalidInputMessage(choice);
                }
            }
        }while(displayMenu);
    }

    public static void SaveVehicle(IVehicle vehicle)
    {
        switch (vehicle.VehicleTypeEnum)
        {
            case VehicleTypeEnum.Truck:
                var truckRepository = VehicleRepositoryFactory.BuildTruckRepo();
                var truck = (Truck)vehicle;
                truckRepository.SaveVehicle(truck);
                break;
            case VehicleTypeEnum.Car:
                var carRepository = VehicleRepositoryFactory.BuildCarRepo();
                var car = (Car)vehicle;
                carRepository.SaveVehicle(car);
                break;
            case VehicleTypeEnum.SUV:
                var suvRepository = VehicleRepositoryFactory.BuildSuvRepo();
                var suv = (Suv)vehicle;
                suvRepository.SaveVehicle(suv);
                break;
            default:
                break;
        }
    }
}