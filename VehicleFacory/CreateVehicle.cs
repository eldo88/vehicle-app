namespace vehicle_app;

public class CreateVehicle
{
    public static Vehicle CreateVehicleFromMenuChoices(VehicleColor vehicleColor, VehicleEngine vehicleEngine, VehicleMake vehicleMake, VehicleModel vehicleModel, VehicleType vehicleType, Dictionary<string, int> menuChoices)
    {
        Vehicle? createdVehicle = null;
        VehicleCreator carCreator = new CarCreator();
        VehicleCreator truckCreator = new TruckCreator();
        VehicleCreator suvCreator = new SuvCreator();

        var createdVehicleType = vehicleType.GetVehicleTypeByIdx(menuChoices["vehicle"] - 1);
        var createdMake = vehicleMake.GetVehicleMakeByIdx(menuChoices["make"] - 1);
        var vehicleMakeKey = createdMake + createdVehicleType;
        var createdModel = vehicleModel.GetVehicleModelByIdx(vehicleMakeKey, menuChoices["model"] - 1);
        var createdEngineType = vehicleEngine.GetEngineTypeByIdx(menuChoices["engine"] - 1);
        var createdVehicleColor = vehicleColor.GetVehicleColorByIdx(menuChoices["color"] - 1);
        var MPG = 25; //hardcoded for now
        var occupantCapacity = 4; // hardcoded for now

        try
        {
            switch(createdVehicleType)
            {
                case "Car":
                    createdVehicle = (Car)carCreator
                                        .VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
                    break;
                case "Truck":
                    createdVehicle = (Truck)truckCreator
                                        .VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
                    break;
                case "SUV":
                    createdVehicle = (Suv)suvCreator
                                        .VehicleFactory(createdVehicleColor, occupantCapacity, createdMake, createdModel, menuChoices["year"], createdVehicleType, createdEngineType, MPG);
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
            throw new ArgumentNullException(createdVehicleType);
        } 

        return createdVehicle;
    }
}