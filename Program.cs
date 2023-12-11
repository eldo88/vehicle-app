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
                Console.WriteLine("Car");
                break;
            case 2:
                vehicleType = VehicleType.Truck;
                Console.WriteLine("Truck");
                break;
            case 3:
                vehicleType = VehicleType.SUV;
                occupantCapacity = 2;
                Console.WriteLine("Motorcycle");
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
                Console.WriteLine("V6");
                break;
            case 2:
                engineType = "V8";
                MPG = 18;
                Console.WriteLine("V8");
                break;
            case 3:
                engineType = "V6 Hybrid";
                MPG = 35;
                Console.WriteLine("V6 Hybrid");
                break;
            case 4:
                engineType = "Electric";
                MPG = 0;
                Console.WriteLine("Electric");
                break;
            default:
                Console.WriteLine("Exit");
                break;
        }


        Car car = new Car("blue", occupantCapacity, make, model, 1997, vehicleType, engineType, MPG);
        Console.WriteLine(car);
    }
}
