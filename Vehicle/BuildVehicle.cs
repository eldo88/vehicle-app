using vehicle_app.Builder;
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
    
    public static IMotorizedVehicle BuildFromMenuChoices(Dictionary<string, string> menuData)
    {
        var engine = BuildEngine(menuData);
        var wheels = new Wheels(menuData["make"], menuData["type"]);
        var tires = new Tires(menuData["type"]);

        return menuData["type"] switch
        {
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
            
            "Truck" => TruckBuilder.Create()
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
            
            "SUV" => SuvBuilder.Create()
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
            _ => new Car(menuData["color"], 4, menuData["make"], menuData["model"], int.Parse(menuData["year"]), menuData["type"], menuData["engine"], 25, int.Parse(menuData["mileage"]), engine, wheels, tires)
        }; // TODO change default selection to empty vehicle or throw exception
    }

    private static IEngine BuildEngine(Dictionary<string, string> menuData)
    {
        var fuelType = EngineHelper.GetFuelType(menuData["engine"]);
        var numberOfCylinders = EngineHelper.GetNumberOfCylinders(menuData["engine"]);
        var hasTurbo = EngineHelper.HasTurbo(menuData["engine"]);
        var engine = EngineBuilder.Create()
            .WithFuelType(fuelType)
            .WithNumberOfCylinders(numberOfCylinders)
            .WithTurbo(hasTurbo)
            .Build();
        return engine;
    }
}