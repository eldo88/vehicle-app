namespace vehicle_app;

public class DisplayVehicleStats
{
    public delegate int NumberTraitDelegate(VehicleStats stats);

    public delegate string VehicleCharacteristic(VehicleStats stats);

    public string VehicleWithHighestTraitByName(List<VehicleStats> allStats, NumberTraitDelegate num)
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

    public Dictionary<string, int> MostCommon(List<VehicleStats> statsList, VehicleCharacteristic vehicleCharacteristic)
    {
        var characteristicCount = new Dictionary<string, int>();
        
        statsList.ForEach(stat =>
        {
            try
            {
                var characteristic = vehicleCharacteristic.Invoke(stat);
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