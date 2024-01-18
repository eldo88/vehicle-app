namespace vehicle_app;

internal class TruckRepository : IVehicleRepository<Truck>
{
    public Truck GetVehicle()
    {
        throw new NotImplementedException();
    }

    public void SaveVehicle(Truck truck)
    {
        var filePath = "./data/vehicle-data/trucks-saved.csv";
        Func<List<string>> data = truck.FormatDataForSavingToFile;
        List<string> truckData = data();

        using StreamWriter streamWriter = File.AppendText(filePath);
        foreach (var line in truckData)
        {
            streamWriter.Write(line + ',');
        }
        streamWriter.WriteLine();
    }
}