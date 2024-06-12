
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
        var trucks = GetVehicles();
        return trucks.FindAll(t => t.Model == model);
    }

    public List<Truck> GetVehicles()
    {
        using StreamReader fileReader = new(File.OpenRead(MockDbFilePath));
        var jd = fileReader.ReadToEnd();

        List<Truck>? trucks = new();

        if (!string.IsNullOrWhiteSpace(jd))
        {
            try
            {
                trucks = JsonSerializer.Deserialize<List<Truck>>(jd);
            }
            catch (Exception e) when
                (e is ArgumentNullException 
                    or JsonException 
                    or NotSupportedException)
            {
                Console.WriteLine($"An error occurred during deserialization {e.Message}");
            }
        }
        
        if (trucks is null)
        {
            throw new NullReferenceException();
        }
        return trucks;
    }

    public void SaveVehicle(Truck truck)
    {
        var data = FileOperations.LoadDataFromDbFile(MockDbFilePath);

        if (string.IsNullOrWhiteSpace(data)) return;
        try
        {
            var trucks = JsonSerializer.Deserialize<List<Truck>>(data);
            if (trucks is null) return;
            trucks.Add(truck);
                    
            var options = new JsonSerializerOptions(){WriteIndented=true};
            var jsonData = JsonSerializer.Serialize<IList<Truck>>(trucks, options);
            using StreamWriter streamWriter = new(MockDbFilePath, false);
            streamWriter.Write(jsonData);
        }
        catch(Exception e) when 
        (
            e is ArgumentNullException 
                or JsonException 
                or NotSupportedException
                or ObjectDisposedException
                or IOException
        )
        {
            Console.WriteLine($"An error occurred while saving vehicle {e.Message}");
        }
    }

    public IEnumerable<Truck> GetVehicleByMake(string make)
    {
        var trucks = GetVehicles();
        return trucks.Where(t => t.Make == make)
                    .OrderByDescending(t => t.Year);
    }
}