
namespace vehicle_app;

internal class CarRepository : IVehicleRepository<Car>
{
    private readonly List<List<string>> _cars = [];
    private const string MockDbFilePath = "./data/vehicle-data/cars-saved.csv";

    public Car GetVehicleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Car> GetVehicleByMake(string make)
    {
        List<Car> cars = GetVehicles();
        return cars.FindAll(c => c.Make == make);
    }

    public List<Car> GetVehicleByModel(string model)
    {
        List<Car> cars = GetVehicles();
        return cars.FindAll(c => c.Model == model);
    }

    public List<Car> GetVehicles()
    {
        List<Car> cars = [];
        FileOperations.ReadDataFromMockDbFile(MockDbFilePath, _cars);

        foreach (var line in _cars)
        {
            var capacity = int.Parse(line[2]);
            var year = int.Parse(line[5]);
            var mpg = int.Parse(line[8]);
            Car car = (Car)VehicleFactory.Build(line[1], capacity, line[3], line[4], year, line[6], line[7], mpg);
            cars.Add(car);
        }

        return cars;
    }

    public void SaveVehicle(Car car)
    {
        var filePath = "./data/vehicle-data/cars-saved.csv";
        var carData = FormatData.ParseVehicleDataForSavingToFile(car);

        using StreamWriter streamWriter = File.AppendText(filePath);
        FileOperations.WriteDataToFile(streamWriter, carData);
    }
}