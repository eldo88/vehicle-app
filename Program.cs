namespace vehicle_app;

class Program
{
    static void Main(string[] args)
    {
        
        VehicleType vehicleType = VehicleType.Car;
        
        var menuChoices = DisplayMenus.MainMenu();
  

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
                vehicleType = VehicleType.Motorcycle;
                Console.WriteLine("Motorcycle");
                break;
        }

        string engineType = "";
        int MPG = 0; 
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


        Car car = new Car("blue", 4, "Toyota", "4Runner", 1997, vehicleType, engineType, MPG);
        Console.WriteLine(car);
    }
}
