namespace vehicle_app;

public class ShowStats
{
    private readonly CalcVehicleStats _vehicleStats = new();
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
        try
        {
            StandardUiMessages.MenuSeparator();
            var highestMileage = _vehicleStats.VehicleWithHighestTraitByName(statsList, stats => stats.Mileage);
            Console.WriteLine($"Vehicle with the highest mileage: {highestMileage}");

            StandardUiMessages.MenuSeparator();
            var highestYear = _vehicleStats.VehicleWithHighestTraitByName(statsList, stats => stats.Year);
            Console.WriteLine($"Newest vehicle: {highestYear}");

            StandardUiMessages.MenuSeparator();
            var mostCommonColors = _vehicleStats.MostCommon(statsList, stats => stats.Color);

            Console.WriteLine("Vehicle Count by Color");
            foreach (var mostCommonColor in mostCommonColors)
            {
                Console.WriteLine($"Color: {mostCommonColor.Key} Vehicle Count: {mostCommonColor.Value}");
            }

            StandardUiMessages.MenuSeparator();
            Console.WriteLine("Vehicle Count by Model");
            var mostCommonModel = _vehicleStats.MostCommon(statsList, stats => stats.Model);

            foreach (var model in mostCommonModel)
            {
                Console.WriteLine($"Model: {model.Key} Vehicle Count: {model.Value}");
            }

            StandardUiMessages.MenuSeparator();
            Console.WriteLine("Vehicle Count by make");
            var mostCommonMake = _vehicleStats.MostCommon(statsList, stats => stats.Make);

            foreach (var make in mostCommonMake)
            {
                Console.WriteLine($"Make: {make.Key} Vehicle Count: {make.Value}");
            }
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (InvalidOperationException ioe)
        {
            Console.WriteLine(ioe);
            throw;
        }
    }
}