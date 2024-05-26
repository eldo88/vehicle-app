namespace vehicle_app;

public static class VehicleMileageMenu
{
    public static int Show(ref int menuControl, MenuChoices menuChoices)
    {
        var vehicleMileage = 0;
        var displayMenu = true;

        do
        {
            StandardUiMessages.MenuSeparator();
            Console.WriteLine("Enter the mileage for your vehicle, enter 1 to go back");

            var inputStr = Console.ReadLine();

            if (int.TryParse(inputStr, out var result) && result > 1)
            {
                vehicleMileage = result;
                menuChoices.MenuChoicesFromUserInput["mileage"] = result;
                menuControl += MenuActions.GoToPreviousNextOrSameMenu(2, 1);
                displayMenu = false;
            }
            else if(result == 1)
            {
                menuControl += MenuActions.GoToPreviousNextOrSameMenu(1, result);
                return result;
            }
            else
            {
                StandardUiMessages.GeneralInvalidInput();
            }

        } while(displayMenu);

        return vehicleMileage;
    }
}