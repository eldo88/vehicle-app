using vehicle_app.Vehicle.Wheels;

namespace vehicle_app;

public static class BuildVehicle
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
        var fuelType = EngineHelper.GetFuelType(menuData["engine"]);
        var numberOfCylinders = EngineHelper.GetNumberOfCylinders(menuData["engine"]);
        var hasTurbo = EngineHelper.HasTurbo(menuData["engine"]);
        var engine = EngineFactory.Build(fuelType, numberOfCylinders, hasTurbo);
        var wheels = new Wheels(menuData["make"], menuData["type"]);
        var tires = new Tires(menuData["type"]);

        return menuData["type"] switch
        {
            //"Car" => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"]), engine, wheels, tires),
            "Car" => CarBuilder.Create()
                .WithColor(menuData["color"])
                .WithCapacity(4)
                .WithMake(menuData["make"])
                .WithModel(menuData["model"])
                .WithYear(int.Parse(menuData["year"]))
                .OfType(menuData["type"])
                .WithEngineType(menuData["engine"], 25)
                .WithMpg(25)
                .WithMileage(int.Parse(menuData["mileage"]))
                .WithEngine(engine)
                .WithWheels(wheels)
                .WithTires(tires)
                .Build(),


            "Truck" => new Truck(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"]), engine, wheels, tires),
            "SUV" => new Suv(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"]), engine, wheels, tires),
            _ => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"]), engine, wheels, tires)
        };
    }
}