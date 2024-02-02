namespace vehicle_app;

public class FormatData
{
    public static List<string> ParseVehicleDataForSavingToFile(IMotorizedVehicle motorizedVehicle)
    {
        var guid = motorizedVehicle.Guid.ToString();
        var capacity = Convert.ToString(motorizedVehicle.Capacity);
        var year = Convert.ToString(motorizedVehicle.Year);
        var vehicleType = Enum.GetName(typeof(VehicleTypeEnum), motorizedVehicle.VehicleTypeEnum);
        var mpg = Convert.ToString(motorizedVehicle.MPG);
        var range = Convert.ToString(motorizedVehicle.Range);
        var fuelCapacity = Convert.ToString(motorizedVehicle.FuelCapacity);
        List<string> data = [];

        if (vehicleType is not null)
        {
            data = [guid, motorizedVehicle.Color, capacity, motorizedVehicle.Make, motorizedVehicle.Model, year, vehicleType, motorizedVehicle.EngineType, mpg, range, fuelCapacity];
        }
        return data;
    }
}
