namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        
        VehicleType vehicleType;
        
        var choice = DisplayMenus.MainMenu();
  

        switch (choice) 
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
    }
}
