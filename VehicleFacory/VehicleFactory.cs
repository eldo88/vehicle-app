namespace vehicle_app;

public static class VehicleFactory
{
    public static IVehicle Build(string vehicleType, int capacity, string v)
    {
        switch(vehicleType)
        {
            case "Car":
                return new Car();
            case "Truck":
                return new Truck();
            case "SUV":
                return new Suv();
            default:
                return new Car();
        }
    }

    public static IVehicle Build(string vehicleColor, int occupantCapacity, string vehicleMake, string vehicleModel, int year, string vehicleType, string vehicleEngine, int MPG)
    {

        switch(vehicleType)
        {
            case "Car":
                return new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG);
            case "Truck":
                return new Truck(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG);
            case "SUV":
                return new Suv(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG);
            default:
                return new Car(vehicleColor, occupantCapacity, vehicleMake, vehicleModel, year, vehicleType, vehicleEngine, MPG);
        }
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

        switch(createdVehicleType)
        {
            case "Car":
                return new Car(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
            case "Truck":
                return new Truck(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
            case "SUV":
                return new Suv(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
            default:
                return new Car();
        }
    }
}