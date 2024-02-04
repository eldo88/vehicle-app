namespace vehicle_app;

public static class DisplayCreatedVehicle
{
    public static void PrintToConsole(IVehicle createdVehicle)
    {
        Console.WriteLine(createdVehicle);
    }

    public static void PrintDriveDetails(List<(string, decimal)> tripDetails)
    {
        Console.WriteLine("\nThe details of your drive are:\n");
        foreach (var item in tripDetails)
        {
            Console.WriteLine("{0}: {1:0.00}", item.Item1, item.Item2);
        }
    }
}