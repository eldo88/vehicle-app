namespace vehicle_app;

public class Menus
{
    public static int VehicleYearSelectionMenu()
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

    public static bool TakeVehicleOnDriveMenu(string vehicleMake, string vehicleModel)
    {
        var drive = false;
        var displayMenu = true;
        do
        {
            StandardUiMessages.TakeOnDriveMessage(vehicleMake, vehicleModel);
        
            var choice = Console.ReadLine();

            var validInput = char.TryParse(choice, out char result);

            if (validInput)
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

    public static int DriveLengthMenu()
    {
        StandardUiMessages.DriveLengthMessage();

        var driveLengthInMiles = Console.ReadLine();
        var validInput = int.TryParse(driveLengthInMiles, out int result);

        if (validInput && result > 0)
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

    public static int ShowMenuItems(List<string> menuItems, string menuText)
    {
        StandardUiMessages.MenuSeparator();
        StandardUiMessages.MenuSubject(menuText);

        var menuItemNum = 1;
        foreach (var item in menuItems)
        {
            StandardUiMessages.ShowMenuItemsInUi(menuItemNum, item);
            menuItemNum++;
        }

        StandardUiMessages.GoBack(menuItemNum);
        StandardUiMessages.MenuSeparator();
        StandardUiMessages.EnterMenuChoice();

        return menuItemNum;
    }

    public static int MenuInput(int menuItemNum)
    {
        var choiceStr = Console.ReadLine();
        var validInput = int.TryParse(choiceStr, out int result);

        if (validInput && result >= 1 && result <= menuItemNum)
        {
            return result;
        }
        else if (choiceStr is not null)
        {
            StandardUiMessages.InvalidInputMessage(choiceStr);
            result = 0;
        }

        return result;
    }

    public static int GoToPreviousNextOrSameMenu(int menuItemNum, int menuChoice)
    {
        var changeMenuValue = 0;

        if (menuItemNum == menuChoice)
        {
            return changeMenuValue - 1;
        }
        else if (menuChoice < 1 || menuChoice > menuItemNum)
        {
            return changeMenuValue;
        }
        else 
        {
            return changeMenuValue + 1;
        }
    }
}