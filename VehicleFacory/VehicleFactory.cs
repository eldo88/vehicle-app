namespace vehicle_app;

public static class VehicleFactory
{
    public static IVehicle Build(string vehicleType)
    {
        return vehicleType switch
        {
            "Car" => new Car(),
            "Truck" => new Truck(),
            "SUV" => new Suv(),
            _ => new Car(),
        };
    }

    public static IVehicle Build(string vehicleColor, int occupantCapacity, string vehicleMake, string vehicleModel, int year, string vehicleType, string vehicleEngine, int MPG)
    {
        return vehicleType switch
        {
            "Car" => new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
            "Truck" => new Truck(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
            "SUV" => new Suv(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
            _ => new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG),
        };
    }

    public static IVehicle BuildFromMenuChoices(VehicleColor vehicleColor, VehicleEngine vehicleEngine, VehicleMake vehicleMake, VehicleModel vehicleModel, VehicleType vehicleType, Dictionary<string, int> menuChoices)
    { 
        var createdVehicleType = vehicleType.GetVehicleTypeByIdx(menuChoices["vehicle"] - 1);
        var createdMake = vehicleMake.GetVehicleMakeByIdx(menuChoices["make"] - 1);
        var vehicleMakeKey = createdMake + createdVehicleType;
        var createdModel = vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, menuChoices["model"] - 1);
        var createdEngineType = vehicleEngine.GetEngineTypeByIdx(menuChoices["engine"] - 1);
        var createdVehicleColor = vehicleColor.GetVehicleColorByIdx(menuChoices["color"] - 1);
        var MPG = 25; //hardcoded for now
        var occupantCapacity = 4; // hardcoded for now

        return createdVehicleType switch
        {
            "Car" => new Car(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG),
            "Truck" => new Truck(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG),
            "SUV" => new Suv(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG),
            _ => new Car(),
        };
    }
}