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
                Console.WriteLine("Car");
                break;
            case 2:
                vehicleType = VehicleType.Truck;
                Console.WriteLine("Truck");
                break;
            case 3:
                vehicleType = VehicleType.Motorcycle;
                Console.WriteLine("Motorcycle");
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


        Car car = new Car("blue", 4, "Toyota", "4Runner", 1997, VehicleType.Truck);
        Console.WriteLine(car);
    }
}
