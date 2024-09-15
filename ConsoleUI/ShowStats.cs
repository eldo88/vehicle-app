namespace vehicle_app;

public class ShowStats
{
    private DisplayVehicleStats _vehicleStats = new DisplayVehicleStats();
    public void Show()
    {
        var loadStats = new LoadVehicleStats();
        var vehicleStats = loadStats.GetVehicleStats();
        DisplayStats(vehicleStats);
        Console.WriteLine();
        StandardUiMessages.PressAnyKeyToContinue();
        Console.WriteLine();
        Console.ReadKey();
    }
    
    private void DisplayStats(List<VehicleStats> statsList)
    {
        var highestMileage = _vehicleStats.VehicleWithHighestTraitByName(statsList, stats => stats.Mileage);
        Console.WriteLine($"Highest mileage: {highestMileage}");
        
        var highestYear = _vehicleStats.VehicleWithHighestTraitByName(statsList, stats => stats.Year);
        Console.WriteLine($"Newest vehicle: {highestYear}");
        
        var mostCommonColors = _vehicleStats.MostCommon(statsList, stats => stats.Color);
        
        foreach (var mostCommonColor in mostCommonColors)
        {
            Console.WriteLine($"Color: {mostCommonColor.Key} amount: {mostCommonColor.Value}");
        }
        
        var mostCommonModel = _vehicleStats.MostCommon(statsList, stats => stats.Model);
        
        foreach (var model in mostCommonModel)
        {
            Console.WriteLine($"Model: {model.Key} amount: {model.Value}");
        }
        
        var mostCommonMake = _vehicleStats.MostCommon(statsList, stats => stats.Make);
        
        foreach (var make in mostCommonMake)
        {
            Console.WriteLine($"Make: {make.Key} amount: {make.Value}");
        }
    }
}