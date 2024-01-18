namespace vehicle_app;

internal class SuvRepository : IVehicleRepository<Suv>
{
    public List<Suv> GetVehicles()
    {
        throw new NotImplementedException();
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