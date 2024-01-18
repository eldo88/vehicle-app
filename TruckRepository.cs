namespace vehicle_app;

internal class TruckRepository : IVehicleRepository<Truck>
{
    public List<Truck> GetVehicles()
    {
        throw new NotImplementedException();
    }

    public void SaveVehicle(Truck truck)
    {
        var filePath = "./data/vehicle-data/trucks-saved.csv";
        var truckData = truck.FormatDataForSavingToFile();

        using StreamWriter streamWriter = File.AppendText(filePath);
        foreach (var line in truckData)
        {
            streamWriter.Write(line + ',');
        }
        streamWriter.WriteLine();
    }
}