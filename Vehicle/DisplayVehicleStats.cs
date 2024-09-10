namespace vehicle_app;

public class DisplayVehicleStats
{
    private delegate int NumberTraitDelegate(VehicleStats stats);

    private delegate string VehicleCharacterstic(VehicleStats stats);

    public void DisplayStats(List<VehicleStats> statsList)
    {
        var highestMileage = VehicleWithHighestTraitByName(statsList, stats => stats.Mileage);
        Console.WriteLine($"Highest mileage: {highestMileage}");
        var highestYear = VehicleWithHighestTraitByName(statsList, stats => stats.Year);
        Console.WriteLine($"Newest vehicle: {highestYear}");
        var mostCommonColors = MostCommon(statsList, stats => stats.Color);
        foreach (var mostCommonColor in mostCommonColors)
        {
            Console.WriteLine($"Color: {mostCommonColor.Key} amount: {mostCommonColor.Value}");
        }
        var mostCommonModel = MostCommon(statsList, stats => stats.Model);
        foreach (var model in mostCommonModel)
        {
            Console.WriteLine($"Model: {model.Key} amount: {model.Value}");
        }
        var mostCommonMake = MostCommon(statsList, stats => stats.Make);
        foreach (var make in mostCommonMake)
        {
            Console.WriteLine($"Make: {make.Key} amount: {make.Value}");
        }
    }

    private string VehicleWithHighestTraitByName(List<VehicleStats> allStats, NumberTraitDelegate num)
    {
        var name = "";
        var topNumber = 0;
        
        allStats.ForEach(stat =>
        {
            try
            {
                var number = num.Invoke(stat);
                if (number <= topNumber) return;
                topNumber = number;
                name = stat.Make + " " + stat.Model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });

        return name;
    }

    private Dictionary<string, int> MostCommon(List<VehicleStats> statsList, VehicleCharacterstic vehicleCharacterstic)
    {
        var characteristicCount = new Dictionary<string, int>();
        
        statsList.ForEach(stat =>
        {
            try
            {
                var characteristic = vehicleCharacterstic(stat);
                if (!characteristicCount.TryAdd(characteristic, 1))
                {
                    characteristicCount[characteristic]++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });

        return characteristicCount;
    }
}