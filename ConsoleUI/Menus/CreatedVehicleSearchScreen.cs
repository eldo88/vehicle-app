namespace vehicle_app;

public class CreatedVehicleSearchScreen
{
    public static void Show()
    {
        Console.WriteLine();
        StandardUiMessages.MenuSeparator();
        var menuText = "make";
        Console.WriteLine("Search Criteria");
        var makes = MenuDataFactory.CreateVehicleMake();
        var menuItemNum = MenuActions.ShowMenuItems(makes.VehicleMakeList, menuText);
        var choiceNum = Input.MenuInput(menuItemNum);
        var choice = CreatedVehicleSearch(choiceNum);
        var car = VehicleRepositoryFactory.BuildCarRepo();
        var truck = VehicleRepositoryFactory.BuildTruckRepo();
        var suv = VehicleRepositoryFactory.BuildSuvRepo();

        if (!string.IsNullOrWhiteSpace(choice))
        {
            var carList = car.GetVehicleByMake(choice);
            var truckList = truck.GetVehicleByMake(choice);
            var suvList = suv.GetVehicleByMake(choice);
            ShowCars(carList);
            ShowTrucks(truckList);
            ShowSuvs(suvList);
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

    public static void ShowCars(List<Car> cars)
    {
        if (cars.Count <= 0)
        {
            Console.WriteLine("No cars found");
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Make} {car.Model} {car.Color}");
        }
    }

    public static void ShowTrucks(List<Truck> trucks)
    {
        if (trucks.Count <= 0)
        {
            Console.WriteLine("No trucks found");
        }

        foreach (var truck in trucks)
        {
            Console.WriteLine($"{truck.Make} {truck.Model} {truck.Color}");
        }
    }

    public static void ShowSuvs(List<Suv> suvs)
    {
        if (suvs.Count <= 0)
        {
            Console.WriteLine("No SUVs found");
        }

        foreach (var suv in suvs)
        {
            Console.WriteLine($"{suv.Make} {suv.Model} {suv.Color}");
        }
    }
}
