namespace vehicle_app;

public static class VehicleFactory
{
    public static IMotorizedVehicle Build(string vehicleType)
    {
        return vehicleType switch
        {
            "Car" => new Car(),
            "Truck" => new Truck(),
            "SUV" => new Suv(),
            _ => new Car(),
        };
    }

    public static IMotorizedVehicle Build(string vehicleColor, int occupantCapacity, string vehicleMake, string vehicleModel, int year, string vehicleType, string vehicleEngine, int MPG)
    {
        return vehicleType switch
        {
            "Car" => new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
            "Truck" => new Truck(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
            "SUV" => new Suv(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
            _ => new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
        };
    }

    public static IMotorizedVehicle BuildFromMenuChoices(Dictionary<string, string> menuData)
    {
        return menuData["type"] switch
        {
            "Car" => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25),
            "Truck" => new Truck(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25),
            "SUV" => new Suv(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25),
            _ => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25)
        };
    }
}