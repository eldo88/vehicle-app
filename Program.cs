using System.Runtime.CompilerServices;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        Menus menus = new();
        
        // menus.MainMenu();
        menus.DisplayMenus();

        var menuChoices = menus.GetMenuChoices();
  
        var occupantCapacity = 4; // hardcoded for now

        if (menuChoices["vehicle"] == 99)
        {
            Console.WriteLine("Exiting program.....");
            return;
        }

        var vehicleType = menus.GetVehicleTypeByIdx(menuChoices["vehicle"] - 1);

        var make = menus.GetVehicleMakeByIdx(menuChoices["make"] - 1);

        var vehicleMakeKey = make + vehicleType;
        var model = menus.GetVehicleModelByIdx(vehicleMakeKey, menuChoices["model"] - 1);
       
        var engineType = menus.GetEngineTypeByIdx(menuChoices["engine"] - 1);

        var vehicleColor = menus.GetVehicleColorByIdx(menuChoices["color"] - 1);
        
        var MPG = 25; //hardcoded for now

        VehicleCreator carCreator = new CarCreator();
        VehicleCreator truckCreator = new TruckCreator();
        VehicleCreator suvCreator = new SuvCreator();

        if (vehicleType == "Car")
        {
            Car car = (Car)carCreator.VehicleFactory(vehicleColor, occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);
            
            if (Menus.TakeVehicleOnDriveMenu(car.Make, car.Model))
            {
                var driveLength = Menus.DriveLengthMenu();
                var tripDetails = car.Drive(driveLength);
                Console.WriteLine(car);
                car.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(car);
            }

            CarRepository carRepository = new();
            carRepository.SaveVehicle(car);
            var cars = carRepository.GetVehicles();
            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
            //Console.ReadLine();
        } 
        else if (vehicleType == "Truck")
        {
            Truck truck = (Truck)truckCreator.VehicleFactory(vehicleColor, occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);

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
        else if (vehicleType == "SUV")
        {
            Suv suv = (Suv)suvCreator.VehicleFactory(vehicleColor, occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);

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
