namespace vehicle_app;

public class CreateVehicle
{
    public CreateVehicle(VehicleColor vehicleColor, VehicleEngine vehicleEngine, VehicleMake vehicleMake, VehicleModel vehicleModel, VehicleType vehicleType, Dictionary<string, int> menuChoicesFromUser)
    {
        VehicleColor = vehicleColor;
        VehicleEngine = vehicleEngine;
        VehicleMake = vehicleMake;
        VehicleModel = vehicleModel;
        VehicleType = vehicleType;
        MenuChoices = menuChoicesFromUser;
    }

    readonly VehicleColor VehicleColor;
    readonly VehicleEngine VehicleEngine;
    readonly VehicleMake VehicleMake;
    readonly VehicleModel VehicleModel;
    readonly VehicleType VehicleType;
    readonly Dictionary<string, int> MenuChoices = [];
    Vehicle? createdVehicle;

    public Vehicle CreateVehicleFromMenuChoices()
    {
        VehicleCreator carCreator = new CarCreator();
        VehicleCreator truckCreator = new TruckCreator();
        VehicleCreator suvCreator = new SuvCreator();

        var createdVehicleType = VehicleType.GetVehicleTypeByIdx(MenuChoices["vehicle"] - 1);
        var createdMake = VehicleMake.GetVehicleMakeByIdx(MenuChoices["make"] - 1);
        var vehicleMakeKey = createdMake + createdVehicleType;
        var createdModel = VehicleModel.GetVehicleModelByIdx(vehicleMakeKey, MenuChoices["model"] - 1);
        var createdEngineType = VehicleEngine.GetEngineTypeByIdx(MenuChoices["engine"] - 1);
        var createdVehicleColor = VehicleColor.GetVehicleColorByIdx(MenuChoices["color"] - 1);
        var MPG = 25; //hardcoded for now
        var occupantCapacity = 4; // hardcoded for now

        try
        {
            switch(createdVehicleType)
            {
                case "Car":
                    createdVehicle = (Car)carCreator
                                        .VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, MenuChoices["year"], createdVehicleType, createdEngineType, MPG);
                    break;
                case "Truck":
                    createdVehicle = (Car)carCreator
                                        .VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, MenuChoices["year"], createdVehicleType, createdEngineType, MPG);
                    break;
                case "SUV":
                    createdVehicle = (Suv)suvCreator
                                        .VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, MenuChoices["year"], createdVehicleType, createdEngineType, MPG);
                    break;
                default:
                    break;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        if(createdVehicle is null)
        {
            throw new ArgumentNullException();
        } 

        return createdVehicle;
    }
}