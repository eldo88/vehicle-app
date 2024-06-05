namespace vehicle_app;

public static class CreatedVehicleSearchScreen
{
    public static void Show()
    {
        Console.WriteLine();
        StandardUiMessages.MenuSeparator();
        const string menuText = "the make you want to search for";
        Console.WriteLine("Search Criteria");
        var makes = new VehicleMake();
        var searchMenu = new MainMenu(makes.VehicleMakeList, menuText);
        var menuItemNum = makes.VehicleMakeList.Count;
        var choiceNum = searchMenu.Run();
        makes.VehicleMakeList.RemoveAt(menuItemNum - 1);
        var choice = makes.VehicleMakeList.ElementAt(choiceNum);
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

    private static void ShowCars(IEnumerable<Car> cars)
    {
        var enumerable = cars.ToList();
        if (!enumerable.Any())
        {
            Console.WriteLine("\nNo cars found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("List of cars:");
            foreach (var car in enumerable)
            {
                Console.WriteLine($"{car.Year} {car.Make} {car.Model} {car.Color}");
            }
        }
    }

    private static void ShowTrucks(IEnumerable<Truck> trucks)
    {
        var enumerable = trucks.ToList();
        if (!enumerable.Any())
        {
            Console.WriteLine("\nNo trucks found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("List of trucks:");
            foreach (var truck in enumerable)
            {
                Console.WriteLine($"{truck.Year} {truck.Make} {truck.Model} {truck.Color}");
            }
        }
    }

    private static void ShowSuvs(IEnumerable<Suv> suvs)
    {
        var enumerable = suvs.ToList();
        if (!enumerable.Any())
        {
            Console.WriteLine("\nNo SUVs found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("List of SUVs:");
            foreach (var suv in enumerable)
            {
                Console.WriteLine($"{suv.Year} {suv.Make} {suv.Model} {suv.Color}");
            }
        }
    }
}
