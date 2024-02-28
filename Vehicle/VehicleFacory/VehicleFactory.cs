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

    // public static IMotorizedVehicle Build(string vehicleColor, int occupantCapacity, string vehicleMake, string vehicleModel, int year, string vehicleType, string vehicleEngine, int MPG, int currentMileage)
    // {
    //     var fuelType = EngineHelper.GetFuelType(menuData);
    //     var numberOfCylinders = EngineHelper.GetNumberOfCylinders(menuData);
    //     var hasTurbo = EngineHelper.HasTurbo(menuData);
    //     var engine = EngineFactory.Build(fuelType, numberOfCylinders, hasTurbo);
    //     return vehicleType switch
    //     {
    //         "Car" => new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG, currentMileage),
    //         "Truck" => new Truck(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG, currentMileage),
    //         "SUV" => new Suv(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG, currentMileage),
    //         _ => new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG, currentMileage),
    //     };
    // }

    public static IMotorizedVehicle BuildFromMenuChoices(Dictionary<string, string> menuData)
    {
        // var fuelType = EngineHelper.GetFuelType(menuData);
        // var numberOfCylinders = EngineHelper.GetNumberOfCylinders(menuData);
        // var hasTurbo = EngineHelper.HasTurbo(menuData);
        // var engine = EngineFactory.Build(fuelType, numberOfCylinders, hasTurbo);

        return menuData["type"] switch
        {
            "Car" => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"])),
            "Truck" => new Truck(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"])),
            "SUV" => new Suv(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"])),
            _ => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"]))
        };
    }
}