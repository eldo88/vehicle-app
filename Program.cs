namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        
        VehicleType vehicleType;

        DisplayMenus displayMenus = new DisplayMenus();
        
        var choice = displayMenus.MainMenu();
  

        switch (choice["vehicle"]) 
        {
            case 1:
                vehicleType = VehicleType.Car;
                Console.WriteLine("1");
                break;
            case 2:
                vehicleType = VehicleType.Truck;
                Console.WriteLine("2");
                break;
            case 3:
                vehicleType = VehicleType.Motorcycle;
                Console.WriteLine("3");
                break;
        }

        switch (choice["engine"]) 
        {
            case 1:
                Console.WriteLine("V6");
                break;
            case 2:
                Console.WriteLine("V8");
                break;
            case 3:
                Console.WriteLine("V6 Hybrid");
                break;
            case 4:
                Console.WriteLine("Electric");
                break;
            default:
                Console.WriteLine("Exit");
                break;
        }
    }
}
