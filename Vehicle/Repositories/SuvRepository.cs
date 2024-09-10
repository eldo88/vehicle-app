
using System.Text.Json;

namespace vehicle_app;

internal class SuvRepository : IVehicleRepository<Suv>
{
    public delegate bool SearchCriteria();
    private readonly List<List<string>> _suvs = new();
    private const string MockDbFilePath = "./Vehicle/Repositories/SavedData/suvs-saved.json";

    public IEnumerable<Suv> CustomSearch(Suv suv, SearchCriteria searchCriteria)
    {
        var savedSuvs = GetVehicles();
        try
        {
            searchCriteria?.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return savedSuvs;
    }
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
                (e is ArgumentNullException 
                    or JsonException 
                    or NotSupportedException)
            {
                Console.WriteLine($"An error occurred during deserialization {e.Message}");
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
        var data = FileOperations.LoadDataFromDbFile(MockDbFilePath);

        if (string.IsNullOrWhiteSpace(data)) return;
        try
        {
            var suvs = JsonSerializer.Deserialize<List<Suv>>(data);
            if (suvs is null) return;
            suvs.Add(suv);
                    
            var options = new JsonSerializerOptions(){WriteIndented=true};
            var jsonData = JsonSerializer.Serialize<IList<Suv>>(suvs, options);
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
}