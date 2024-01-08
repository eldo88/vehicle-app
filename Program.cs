using System.Runtime.CompilerServices;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        DisplayMenus menus = new();
        
        menus.MainMenu();

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
        
        if (vehicleType == "Car")
        {
            Car car = new(vehicleColor, occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);

            if (DisplayMenus.TakeVehicleOnDriveMenu(car.Make, car.Model))
            {
                var driveLength = DisplayMenus.DriveLengthMenu();
                var tripDetails = car.Drive(driveLength);
                Console.WriteLine(car);
                car.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(car);
            }
        } 
        else if (vehicleType == "Truck")
        {
            Truck truck = new(vehicleColor, occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);

            if (DisplayMenus.TakeVehicleOnDriveMenu(truck.Make, truck.Model))
            {
                var driveLength = DisplayMenus.DriveLengthMenu();
                var tripDetails = truck.Drive(driveLength);
                Console.WriteLine(truck);
                truck.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(truck);
            }
        } 
        else if (vehicleType == "SUV")
        {
            Suv suv = new(vehicleColor, occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);

            if (DisplayMenus.TakeVehicleOnDriveMenu(suv.Make, suv.Model))
            {
                var driveLength = DisplayMenus.DriveLengthMenu();
                var tripDetails = suv.Drive(driveLength);
                Console.WriteLine(suv);
                suv.PrintDriveDetails(tripDetails);
            }
            else
            {
                Console.WriteLine(suv);
            }
        }
        else
        {
            Console.WriteLine("Invalid vehicle type");
        }
    }
}
