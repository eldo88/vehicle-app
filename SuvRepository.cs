namespace vehicle_app;

internal class SuvRepository : IVehicleRepository<Suv>
{
    public Suv GetVehicle()
    {
        throw new NotImplementedException();
    }

    public void SaveVehicle(Suv suv)
    {
        var filePath = "./data/vehicle-data/suvs-saved.csv";
        Func<List<string>> data = suv.FormatDataForSavingToFile;
        List<string> suvData = data();

        using StreamWriter streamWriter = File.AppendText(filePath);
        foreach (var line in suvData)
        {
            streamWriter.Write(line + ',');
        }
        streamWriter.WriteLine();
    }
}