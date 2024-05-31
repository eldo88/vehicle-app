
using System.Text.Json;

namespace vehicle_app;

internal class SuvRepository : IVehicleRepository<Suv>
{
    private readonly List<List<string>> _suvs = new();
    private const string MockDbFilePath = "./Vehicle/Repositories/SavedData/suvs-saved.json";

    public Suv GetVehicleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Suv> GetVehicleByMake(string make)
    {
        var suvs = GetVehicles();
        return suvs.Where(s => s.Make == make)
                    .OrderByDescending(s => s.Year);
    }

    public List<Suv> GetVehicleByModel(string model)
    {
        var suvs = GetVehicles();
        return suvs.FindAll(s => s.Model == model);
    }

    public List<Suv> GetVehicles()
    {
        using StreamReader fileReader = new(File.OpenRead(MockDbFilePath));
        var jd = fileReader.ReadToEnd();

        List<Suv>? suvs = new();

        if (!string.IsNullOrWhiteSpace(jd))
        {
            try
            {
                suvs = JsonSerializer.Deserialize<List<Suv>>(jd);
            }
            catch (Exception e) when
                (e is ArgumentNullException or JsonException or NotSupportedException)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        if (suvs is null)
        {
            throw new NullReferenceException();
        }
        return suvs;
    }

    public void SaveVehicle(Suv suv)
    {
        using StreamReader fileReader = new(File.OpenRead(MockDbFilePath));
        var jd = fileReader.ReadToEnd();

        List<Suv>? suvs = new();

         if (!string.IsNullOrWhiteSpace(jd))
        {
            try
            {
                suvs = JsonSerializer.Deserialize<List<Suv>>(jd);
            }
            catch(Exception e) when 
            (
                e is ArgumentNullException ||
                e is JsonException ||
                e is NotSupportedException
            )
            {
                Console.WriteLine(e.Message);
            }
        }

        if (suvs is null) return;
        suvs.Add(suv);
                    
        var options = new JsonSerializerOptions(){WriteIndented=true};
        var jsonData = JsonSerializer.Serialize<IList<Suv>>(suvs, options);
        using StreamWriter streamWriter = new(MockDbFilePath, false);
        streamWriter.Write(jsonData);
    }
}