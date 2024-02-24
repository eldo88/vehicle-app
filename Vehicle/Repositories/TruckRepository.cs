
using System.Text.Json;

namespace vehicle_app;

internal class TruckRepository : IVehicleRepository<Truck>
{
    private readonly List<List<string>> _trucks = new();
    private const string MockDbFilePath = "./Vehicle/Repositories/SavedData/trucks-saved.json";

    public Truck GetVehicleById(Guid id)
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
        using StreamReader fileReader = new(File.OpenRead(MockDbFilePath));
        var jd = fileReader.ReadToEnd();

        List<Truck>? trucks = new();

        if (!string.IsNullOrWhiteSpace(jd))
        {
            trucks = JsonSerializer.Deserialize<List<Truck>>(jd);
        }
        
        if (trucks is null)
        {
            throw new NullReferenceException();
        }
        return trucks;
    }

    public void SaveVehicle(Truck truck)
    {
        using StreamReader fileReader = new(File.OpenRead(MockDbFilePath));
        var jd = fileReader.ReadToEnd();

        List<Truck>? trucks = new();

        if (!string.IsNullOrWhiteSpace(jd))
        {
            trucks = JsonSerializer.Deserialize<List<Truck>>(jd);
        }

        if (trucks is null)
        {
            trucks = new List<Truck>{truck};
        }
        else
        {
            trucks.Add(truck);
        }
        
        var options = new JsonSerializerOptions(){WriteIndented=true};
        var jsonData = JsonSerializer.Serialize<IList<Truck>>(trucks, options);
        using StreamWriter streamWriter = new(MockDbFilePath, false);
        streamWriter.Write(jsonData);
    }

    public IEnumerable<Truck> GetVehicleByMake(string make)
    {
        List<Truck> trucks = GetVehicles();
        return trucks.Where(t => t.Make == make)
                    .OrderByDescending(t => t.Year);
    }
}