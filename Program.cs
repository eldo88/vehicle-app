using System.Runtime.CompilerServices;

namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        
        VehicleType vehicleType = VehicleType.Car;
        
        var menuChoices = DisplayMenus.MainMenu();
  
        var occupantCapacity = 4;

        switch (menuChoices["vehicle"]) 
        {
            case 1:
                vehicleType = VehicleType.Car;
                break;
            case 2:
                vehicleType = VehicleType.Truck;
                break;
            case 3:
                vehicleType = VehicleType.SUV;
                occupantCapacity = 2;
                break;
            case 4:
                Console.WriteLine("Exiting...");
                return;
            default:
                Console.WriteLine("No choice for vehicle type was made");
                break;
        }

        var make = "";
        switch(menuChoices["make"])
        {
            case 1:
                make = "Toyota";
                break;
            case 2:
                make = "Ford";
                break;
            case 3:
                make = "Chevy";
                break;
            default:
                Console.WriteLine("No make provided");
                break;
        }

        var model = "";
        switch (menuChoices["model"])
        {
            case 1:
                model = "Camry";
                break;
            case 2:
                model = "Corrolla";
                break;
            case 3:
                model = "Prius";
                break;
            case 4:
                model = "Tacoma";
                break;
            case 5:
                model = "Tundra";
                break;
            case 6:
                model = "4Runner";
                break;
            case 7:
                model = "Land Cruiser";
                break;
            case 8:
                model = "Seqoia";
                break;
            default:
                Console.WriteLine("No model provided");
                break;
        }

        var engineType = "";
        var MPG = 0; 
        switch (menuChoices["engine"]) 
        {
            case 1:
                engineType = "V6";
                MPG = 25;
                break;
            case 2:
                engineType = "V8";
                MPG = 18;
                break;
            case 3:
                engineType = "V6 Hybrid";
                MPG = 35;
                break;
            case 4:
                engineType = "Electric";
                MPG = 0;
                break;
            default:
                Console.WriteLine("Exit");
                break;
        }

        if (vehicleType == VehicleType.Car)
        {
            Car car = new Car("blue", occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);
            Console.WriteLine(car);

            var tripDetails = car.Drive(1784);
            car.PrintTripDetails(tripDetails);
        } 
        else if (vehicleType == VehicleType.Truck)
        {
            Truck truck = new Truck("red", occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);
            Console.WriteLine(truck);

            var tripDetails = truck.Drive(2500);
            truck.PrintTripDetails(tripDetails);
        } 
        else if (vehicleType == VehicleType.SUV)
        {
            Suv suv = new Suv("green", occupantCapacity, make, model, menuChoices["year"], vehicleType, engineType, MPG);
            Console.WriteLine(suv);

            var tripDetails = suv.Drive(1000);
            suv.PrintTripDetails(tripDetails);
        }
        else
        {
            Console.WriteLine("Invalid vehicle type");
        }



    }
}
