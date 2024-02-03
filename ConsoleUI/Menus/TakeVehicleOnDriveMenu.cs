namespace vehicle_app;

public class TakeVehicleOnDriveMenu
{
    public static bool GoOnDrive(string vehicleMake, string vehicleModel)
    {
        var drive = false;
        var displayMenu = true;
        do
        {
            StandardUiMessages.TakeOnDriveMessage(vehicleMake, vehicleModel);
        
            var choice = Console.ReadLine();

            if (char.TryParse(choice, out char result))
            {
                if (char.ToLower(result) == 'y')
                {
                    drive = true;
                    displayMenu = false;
                }
                else if (char.ToLower(result) == 'n')
                {
                    drive = false;
                    displayMenu = false;
                }
                else if (choice is not null)
                {
                    StandardUiMessages.InvalidInputMessage(choice);
                }
            }
            
        } while(displayMenu);

        return drive;
    }
}
