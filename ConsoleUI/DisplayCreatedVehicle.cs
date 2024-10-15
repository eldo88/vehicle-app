namespace vehicle_app;

public static class DisplayCreatedVehicle
{
    public static void PrintToConsole(IVehicle createdVehicle)
    {
        Console.WriteLine(createdVehicle);
    }

    public static void PrintDriveDetails(Driver.Driver driver, decimal tripLength)
    {
        var tripDetails = driver.DriveVehicle(tripLength);
        Console.WriteLine($"\nThe details of {driver.GetDriverOfVehicle()}'s drive in the {driver.GetVehicle()} are:\n");
        foreach (var item in tripDetails)
        {
            Console.WriteLine("{0}: {1:0.00}", item.Item1, item.Item2);
        }
    }
}