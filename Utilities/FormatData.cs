namespace vehicle_app;

public class FormatData
{
    public static List<string> ParseVehicleDataForSavingToFile(IMotorizedVehicle motorizedVehicle)
    {
        var guid = motorizedVehicle.Guid.ToString();
        var capacity = Convert.ToString(motorizedVehicle.Capacity);
        var year = Convert.ToString(motorizedVehicle.Year);
        var vehicleType = Enum.GetName(typeof(VehicleTypeEnum), motorizedVehicle.VehicleTypeEnum);
        var mpg = Convert.ToString(motorizedVehicle.Mpg);
        var range = Convert.ToString(motorizedVehicle.Range);
        var fuelCapacity = Convert.ToString(motorizedVehicle.FuelCapacity);
        List<string> data = new();

        if (vehicleType is not null)
        {
            data.Add(guid);
            data.Add(motorizedVehicle.Color);
            data.Add(capacity);
            data.Add(motorizedVehicle.Make);
            data.Add(motorizedVehicle.Model);
            data.Add(year);
            data.Add(vehicleType);
            data.Add(motorizedVehicle.EngineType);
            data.Add(mpg);
            data.Add(range);
            data.Add(fuelCapacity);
        }
        return data;
    }
}
