namespace vehicle_app;

internal class CarRepository : IVehicleRepository<Car>
{
    readonly List<Vehicle> _cars = [];

    public Car GetVehicle()
    {
        throw new NotImplementedException();
    }

    public void SaveVehicle(Car car)
    {
        var filePath = "./data/vehicle-data/cars-saved.csv";
        Func<List<string>> data = car.FormatDataForSavingToFile;
        List<string> carData = data();

        using StreamWriter streamWriter = File.AppendText(filePath);
        foreach (var line in carData)
        {
            streamWriter.Write(line + ',');
        }
        streamWriter.WriteLine();
    }
}