
namespace vehicle_app;

internal class SuvRepository : IVehicleRepository<Suv>
{
    private readonly List<List<string>> _suvs = [];
    private readonly SuvCreator suvCreator = new();

    public Suv GetVehicleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Suv> GetVehicleByMake(string make)
    {
        throw new NotImplementedException();
    }

    public List<Suv> GetVehicleByModel(string model)
    {
        List<Suv> suvs = GetVehicles();
        return suvs.FindAll(s => s.Model == model);
    }

    public List<Suv> GetVehicles()
    {
        List<Suv> suvs = [];
        FileOperations.ReadDataFromMockDbFile("./data/vehicle-data/suvs-saved.csv", _suvs);
        
        foreach (var line in _suvs)
        {
            var capacity = int.Parse(line[2]);
            var year = int.Parse(line[5]);
            var mpg = int.Parse(line[8]);
            Suv suv = (Suv)suvCreator.VehicleFactory(line[1], capacity, line[3], line[4], year, line[6], line[7], mpg);
            suvs.Add(suv);
        }

        return suvs;
    }

    public void SaveVehicle(Suv suv)
    {
        var filePath = "./data/vehicle-data/suvs-saved.csv";
        var suvData = suv.FormatDataForSavingToFile();

        using StreamWriter streamWriter = File.AppendText(filePath);
        foreach (var line in suvData)
        {
            streamWriter.Write(line + ',');
        }
        streamWriter.WriteLine();
    }
}