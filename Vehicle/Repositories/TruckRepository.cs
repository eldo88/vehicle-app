
namespace vehicle_app;

internal class TruckRepository : IVehicleRepository<Truck>
{
    private readonly List<List<string>> _trucks = [];

    public Truck GetVehicleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Truck> GetVehicleByMake(string make)
    {
        throw new NotImplementedException();
    }

    public List<Truck> GetVehicleByModel(string model)
    {
        List<Truck> trucks = GetVehicles();
        return trucks.FindAll(t => t.Model == model);
    }

    public List<Truck> GetVehicles()
    {
        List<Truck> trucks = [];
        FileOperations.ReadDataFromMockDbFile("./data/vehicle-data/trucks-saved.csv", _trucks);
        
        foreach (var line in _trucks)
        {
            var capacity = int.Parse(line[2]);
            var year = int.Parse(line[5]);
            var mpg = int.Parse(line[8]);
            var truck = (Truck)VehicleFactory.Build(line[1], capacity, line[3], line[4], year, line[6], line[7], mpg);
            trucks.Add(truck);
        }

        return trucks;
    }

    public void SaveVehicle(Truck truck)
    {
        var filePath = "./data/vehicle-data/trucks-saved.csv";
        var truckData = FormatData.ParseVehicleDataForSavingToFile(truck);

        using StreamWriter streamWriter = File.AppendText(filePath);
        foreach (var line in truckData)
        {
            streamWriter.Write(line + ',');
        }
        streamWriter.WriteLine();
    }
}