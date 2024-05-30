namespace vehicle_app;

public static class TakeVehicleOnDriveMenu
{
    public static bool GoOnDrive(string vehicleMake, string vehicleModel)
    {
        var drive = false;
        var displayMenu = true;
        do
        {
            StandardUiMessages.TakeOnDriveMessage(vehicleMake, vehicleModel);
        
            var choice = Console.ReadLine();

            if (!char.TryParse(choice, out var result)) continue;
            switch (char.ToLower(result))
            {
                case 'y':
                    drive = true;
                    displayMenu = false;
                    break;
                case 'n':
                    drive = false;
                    displayMenu = false;
                    break;
                default:
                {
                    StandardUiMessages.InvalidInputMessage(choice);

                    break;
                }
            }

        } while(displayMenu);

        return drive;
    }
}
