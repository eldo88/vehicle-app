namespace vehicle_app;

public class CalcVehicleStats
{
    public delegate int NumberTraitDelegate(VehicleStats stats);

    public delegate string VehicleCharacteristic(VehicleStats stats);

    public string VehicleWithHighestTraitByName(List<VehicleStats> allStats, NumberTraitDelegate num)
    {
        var name = "";
        var topNumber = 0;
        
        allStats.ForEach(stat =>
        {
            var number = num.Invoke(stat);
            if (number <= topNumber) return;
            topNumber = number;
            name = stat.Make + " " + stat.Model;
        });
        return name;
    }

    public Dictionary<string, int> MostCommon(List<VehicleStats> statsList, VehicleCharacteristic vehicleCharacteristic)
    {
        var characteristicCount = new Dictionary<string, int>();
        
        statsList.ForEach(stat =>
        {
            var characteristic = vehicleCharacteristic.Invoke(stat);
            if (!characteristicCount.TryAdd(characteristic, 1))
            {
                characteristicCount[characteristic]++;
            }
        });
        return characteristicCount;
    }
}