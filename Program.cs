using System.Runtime.CompilerServices;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        // Menus menus = new();
        VehicleColor vehicleColor = new();
        VehicleEngine vehicleEngine = new();
        VehicleMake vehicleMake = new();
        VehicleModel vehicleModel = new();
        VehicleType vehicleType = new();

        ShowMenus showMenus = new(vehicleColor, vehicleEngine, vehicleMake, vehicleModel, vehicleType);
        
        // menus.MainMenu();
        showMenus.DisplayMenus();

        var menuChoices = showMenus.menuChoices.MenuChoicesFromUserInput;
  
        var occupantCapacity = 4; // hardcoded for now

        if (menuChoices["vehicle"] == 99)
        {
            Console.WriteLine("Exiting program.....");
            return;
        }

        var createdVehicleType = vehicleType.GetVehicleTypeByIdx(menuChoices["vehicle"] - 1);

        var createdMake = vehicleMake.GetVehicleMakeByIdx(menuChoices["make"] - 1);

        var vehicleMakeKey = createdMake + createdVehicleType;
        var createdModel = vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, menuChoices["model"] - 1);
       
        var createdEngineType = vehicleEngine.GetEngineTypeByIdx(menuChoices["engine"] - 1);

        var createdVehicleColor = vehicleColor.GetVehicleColorByIdx(menuChoices["color"] - 1);
        
        var MPG = 25; //hardcoded for now

        VehicleCreator carCreator = new CarCreator();
        VehicleCreator truckCreator = new TruckCreator();
        VehicleCreator suvCreator = new SuvCreator();
        Vehicle createdVehicle;

        if (createdVehicleType == "Car")
        {
            createdVehicle = (Car)carCreator.VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
            
            if (Menus.TakeVehicleOnDriveMenu(createdVehicle.Make, createdVehicle.Model))
            {
                var driveLength = Menus.DriveLengthMenu();
                var tripDetails = createdVehicle.Drive(driveLength);
                Console.WriteLine(createdVehicle);
                createdVehicle.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(createdVehicle);
            }

            CarRepository carRepository = new();
            //carRepository.SaveVehicle(createdVehicle);
            var cars = carRepository.GetVehicles();
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
            //Console.ReadLine();
        } 
        else if (createdVehicleType == "Truck")
        {
            Truck truck = (Truck)truckCreator.VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);

            if (Menus.TakeVehicleOnDriveMenu(truck.Make, truck.Model))
            {
                var driveLength = Menus.DriveLengthMenu();
                var tripDetails = truck.Drive(driveLength);
                Console.WriteLine(truck);
                truck.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(truck);
            }

            TruckRepository truckRepository = new();
            truckRepository.SaveVehicle(truck);
        } 
        else if (createdVehicleType == "SUV")
        {
            Suv suv = (Suv)suvCreator.VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);

            if (Menus.TakeVehicleOnDriveMenu(suv.Make, suv.Model))
            {
                var driveLength = Menus.DriveLengthMenu();
                var tripDetails = suv.Drive(driveLength);
                Console.WriteLine(suv);
                suv.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(suv);
            }
            
            SuvRepository suvRepository = new();
            suvRepository.SaveVehicle(suv);
        }
        else
        {
            Console.WriteLine("Invalid vehicle type");
        }
    }
}
