namespace vehicle_app;

public class Menus
{
    public static int VehicleYearSelectionMenu()
    {
        var vehicleYear = 0;
        var displayMenu = true;

        do
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine($"\nPlease enter the year of your vehicle (must be newer than 1990), if you want to go back enter 1 ");

            var inputStr = Console.ReadLine();
            var validInput = int.TryParse(inputStr, out int result);

            if ((validInput && result >= 1990 && result <= DateTime.Now.Year + 1) || result == 1)
            {
                vehicleYear = result;
                displayMenu = false;
            }
            else
            {
                Console.WriteLine("Year entered not valid, please enter another year");
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
            Console.WriteLine($"Would you like to take your {vehicleMake} {vehicleModel} on a drive? (enter Y/N)");
        
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
                else
                {
                    Console.WriteLine($"{choice} is not a valid input");
                }
            }

        } while(displayMenu);

        return drive;
    }

    public static int DriveLengthMenu()
    {
        Console.WriteLine("\nHow many miles are you driving?");

        var driveLengthInMiles = Console.ReadLine();
        var validInput = int.TryParse(driveLengthInMiles, out int result);

        if (validInput && result > 0)
        {
            return result;
        }
        else
        {
            Console.WriteLine("Default drive length of 20 miles is being used.");
            result = 20;
        }

        return result;
    }

    public static int ShowMenuItems(List<string> menuItems, string menuText)
    {
        Console.WriteLine("***************************************************************");
        Console.WriteLine($"\n Please choose the {menuText} of your vehicle from the following options:");

        var menuItemNum = 1;
        foreach (var item in menuItems)
        {
            Console.WriteLine($"\t{menuItemNum}. {item}");
            menuItemNum++;
        }

        Console.WriteLine($"\t{menuItemNum}. Go Back");
        Console.WriteLine("\n****************************************************************\n");
        Console.Write("Enter an integer value of your choice: ");

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
        else
        {
            Console.WriteLine($"{choiceStr} is not a valid input");
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