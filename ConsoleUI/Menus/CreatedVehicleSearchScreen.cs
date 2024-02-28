namespace vehicle_app;

public class CreatedVehicleSearchScreen
{
    public static void Show()
    {
        Console.WriteLine();
        StandardUiMessages.MenuSeparator();
        var menuText = "the make you want to search for";
        Console.WriteLine("Search Criteria");
        var makes = new VehicleMake();
        var menuItemNum = MenuActions.ShowMenuItems(makes.VehicleMakeList, menuText);
        var choiceNum = Input.MenuInput(menuItemNum);
        var choice = CreatedVehicleSearch(choiceNum);
        var car = VehicleRepositoryFactory.BuildCarRepo();
        var truck = VehicleRepositoryFactory.BuildTruckRepo();
        var suv = VehicleRepositoryFactory.BuildSuvRepo();

        if (!string.IsNullOrWhiteSpace(choice))
        {
            try
            {
                var carList = car.GetVehicleByMake(choice);
                var truckList = truck.GetVehicleByMake(choice);
                var suvList = suv.GetVehicleByMake(choice);
                ShowCars(carList);
                ShowTrucks(truckList);
                ShowSuvs(suvList);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        Console.WriteLine();
    }

    public static string CreatedVehicleSearch(int choice)
    {
        switch (choice)
        {
            case 1:
                return "Toyota";
            case 2:
                return "Ford";
            case 3:
                return "Chevrolet";
            default:
                return "";
        }
    }

    public static void ShowCars(IEnumerable<Car> cars)
    {
        if (!cars.Any())
        {
            Console.WriteLine("\nNo cars found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("List of cars:");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Year} {car.Make} {car.Model} {car.Color}");
            }
        }
    }

    public static void ShowTrucks(IEnumerable<Truck> trucks)
    {
        if (!trucks.Any())
        {
            Console.WriteLine("\nNo trucks found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("List of trucks:");
            foreach (var truck in trucks)
            {
                Console.WriteLine($"{truck.Year} {truck.Make} {truck.Model} {truck.Color}");
            }
        }
    }

    public static void ShowSuvs(IEnumerable<Suv> suvs)
    {
        if (!suvs.Any())
        {
            Console.WriteLine("\nNo SUVs found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("List of SUVs:");
            foreach (var suv in suvs)
            {
                Console.WriteLine($"{suv.Year} {suv.Make} {suv.Model} {suv.Color}");
            }
        }
    }
}
