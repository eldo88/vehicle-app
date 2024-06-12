
using System.Text.Json;

namespace vehicle_app;

internal class CarRepository : IVehicleRepository<Car>
{
    private readonly List<List<string>> _cars = new();
    private const string MockDbFilePath = "./Vehicle/Repositories/SavedData/cars-saved.json";

    public Car GetVehicleById(Guid id)
    {
        throw new NotImplementedException();
    }

    // public List<Car> GetVehicleByMake(string make)
    // {
    //     List<Car> cars = GetVehicles();
    //     return cars.FindAll(c => c.Make == make);
    // }

    public List<Car> GetVehicleByModel(string model)
    {
        var cars = GetVehicles();
        return cars.FindAll(c => c.Model == model);
    }

    public List<Car> GetVehicles()
    {
        using StreamReader fileReader = new(File.OpenRead(MockDbFilePath));
        var jd = fileReader.ReadToEnd();

        List<Car>? cars = new();

        if (!string.IsNullOrWhiteSpace(jd))
        {
            try
            {
                cars = JsonSerializer.Deserialize<List<Car>>(jd);
            }
            catch(Exception e) when 
            (
                e is ArgumentNullException 
                    or JsonException 
                    or NotSupportedException
            )
            {
                Console.WriteLine($"An error occurred during deserialization {e.Message}");
            }
        }
        
        if (cars is null)
        {
            throw new NullReferenceException();
        }
        return cars;
    }

    public void SaveVehicle(Car car)
    {
        var data = FileOperations.LoadDataFromDbFile(MockDbFilePath);

        if (string.IsNullOrWhiteSpace(data)) return;
        try
        {
            var cars = JsonSerializer.Deserialize<List<Car>>(data);
            if (cars is null) return;
            cars.Add(car);
                    
            var options = new JsonSerializerOptions(){WriteIndented=true};
            var jsonData = JsonSerializer.Serialize<IList<Car>>(cars, options);
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

    public IEnumerable<Car> GetVehicleByMake(string make)
    {
        var cars = GetVehicles();
        return cars.Where(c => c.Make == make)
                    .OrderByDescending(c => c.Year);
    }
}