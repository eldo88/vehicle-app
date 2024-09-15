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
        var wheels = BuildWheels(menuData);
        var tires = BuildTires(menuData);

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
        
        return fuelType switch 
        {
            "Gas" => new GasEngine(numberOfCylinders, hasTurbo),
            "Diesel" => new DieselEngine(numberOfCylinders),
            "Electric" => new ElectricMotor(),
            _ => new GasEngine(numberOfCylinders, hasTurbo)
        };
        //var engine = EngineBuilder.Create()
            //.WithFuelType(fuelType)
            //.WithNumberOfCylinders(numberOfCylinders)
            //.WithTurbo(hasTurbo)
            //.Build();
        //return engine;
    }

    private static Wheels BuildWheels(Dictionary<string, string> menuData)
    {
        return new Wheels(menuData["make"], menuData["type"]);
    }

    private static Tires BuildTires(Dictionary<string, string> menuData)
    {
        return new Tires(menuData["type"]);
    }
}