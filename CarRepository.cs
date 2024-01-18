namespace vehicle_app;

internal class CarRepository : IVehicleRepository<Car>
{
    readonly List<string> _cars = [];

    public Car GetVehicle()
    {
        FileOperations.ReadDataFromFile("./data/vehicle-data/cars-saved.csv", _cars);

        foreach (var line in _cars)
        {
            Console.WriteLine(line);
        }

        Car car = new("test", 1, "test", "test", 2, "Car", "test", 3);

        return car;
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