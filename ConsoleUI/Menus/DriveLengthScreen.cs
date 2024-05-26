namespace vehicle_app;

public static class DriveLengthScreen
{
    public static int EnterDriveLength()
    {
        StandardUiMessages.DriveLengthMessage();

        var driveLengthInMiles = Console.ReadLine();

        if (int.TryParse(driveLengthInMiles, out int result) && result > 0)
        {
            return result;
        }
        else
        {
            StandardUiMessages.DriveLengthDefaultMessage();
            result = 20;
        }

        return result;
    }
}
