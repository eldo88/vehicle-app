namespace vehicle_app;

public class VehicleYearMenu
{
    public static int Show()
    {
        var vehicleYear = 0;
        var displayMenu = true;

        do
        {
            StandardUiMessages.MenuSeparator();
            StandardUiMessages.YearSelectionMessage();

            var inputStr = Console.ReadLine();
            var validInput = int.TryParse(inputStr, out int result);

            if ((validInput && result >= 1990 && result <= DateTime.Now.Year + 1) || result == 1)
            {
                vehicleYear = result;
                displayMenu = false;
            }
            else
            {
                StandardUiMessages.GeneralInvalidInput();
            }

        } while(displayMenu);

        return vehicleYear;
    }
}
