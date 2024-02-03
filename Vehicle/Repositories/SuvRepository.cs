
namespace vehicle_app;

internal class SuvRepository : IVehicleRepository<Suv>
{
    private readonly List<List<string>> _suvs = [];
    private const string MockDbFilePath = "./data/vehicle-data/suvs-saved.csv";

    public Suv GetVehicleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Suv> GetVehicleByMake(string make)
    {
        List<Suv> suvs = GetVehicles();
        return suvs.FindAll(s => s.Make == make);
    }

    public List<Suv> GetVehicleByModel(string model)
    {
        List<Suv> suvs = GetVehicles();
        return suvs.FindAll(s => s.Model == model);
    }

    public List<Suv> GetVehicles()
    {
        List<Suv> suvs = [];
        FileOperations.ReadDataFromMockDbFile(MockDbFilePath, _suvs);
        
        foreach (var line in _suvs)
        {
            var capacity = int.Parse(line[2]);
            var year = int.Parse(line[5]);
            var mpg = int.Parse(line[8]);
            Suv suv = (Suv)VehicleFactory.Build(line[1], capacity, line[3], line[4], year, line[6], line[7], mpg);
            suvs.Add(suv);
        }

        return suvs;
    }

    public void SaveVehicle(Suv suv)
    {
        var filePath = "./data/vehicle-data/suvs-saved.csv";
        var suvData = FormatData.ParseVehicleDataForSavingToFile(suv);

        using StreamWriter streamWriter = File.AppendText(filePath);
        FileOperations.WriteDataToFile(streamWriter, suvData);
    }
}