namespace vehicle_app;

public class Menus
{
    public Menus()
    {
        vehicleModelDict = vehicleModel.VehicleModelDict;
        vehicleTypeList = vehicleType.VehicleTypeList;
        vehicleMakeList = vehicleMake.VehicleMakeList;
        engineTypeList = vehicleEngine.EngineList;
        vehicleColorList = vehicleColor.ColorList;
    }

    readonly Dictionary<string, int> menuChoices = [];
    readonly List<string> vehicleTypeList = [];
    readonly VehicleType vehicleType = new();
    readonly List<string> engineTypeList = [];
    readonly VehicleEngine vehicleEngine = new();
    readonly List<string> vehicleMakeList = [];
    readonly VehicleMake vehicleMake = new();
    readonly List<string> vehicleColorList = [];
    readonly VehicleColor vehicleColor = new();
    readonly Dictionary<string, List<string>> vehicleModelDict = [];
    readonly VehicleModel vehicleModel = new();
    
    public Dictionary<string, int> GetMenuChoices()
    {
        return menuChoices;
    }

    public string GetVehicleTypeByIdx(int idx)
    {
        return vehicleTypeList[idx];
    }

    public string GetVehicleMakeByIdx(int idx)
    {
        return vehicleMakeList[idx];
    }

    public string GetVehicleModelByIdx(string vehicleMakeKey, int idx)
    {
        var modelList = vehicleModelDict[vehicleMakeKey];

        return modelList[idx];
    }

    public string GetEngineTypeByIdx(int idx)
    {
        return engineTypeList[idx];
    }

    public string GetVehicleColorByIdx(int idx)
    {
        return vehicleColorList[idx];
    }

    public void DisplayMenus()
    {
        var menuControl = 1;
        var displayMenu = true;
        // LoadModelData();

        do
        {
            int menuItemNum;
            int menuChoice;
            switch (menuControl)
            {
                case 0:
                    menuChoices["vehicle"] = 99;
                    displayMenu = false;
                    break;
                case 1:
                    Console.WriteLine("\nThis program will allow you to build a vehicle");
                    var mainMenuText = "the type";
                    menuItemNum = ShowMenuItems(vehicleTypeList, mainMenuText);
                    menuChoice = MenuInput(menuItemNum);
                    menuChoices["vehicle"] = menuChoice;
                    menuControl += GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 2:
                    var makeMenuText = "make";
                    menuItemNum = ShowMenuItems(vehicleMakeList, makeMenuText);
                    menuChoice = MenuInput(menuItemNum);
                    menuChoices["make"] = menuChoice;
                    menuControl += GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 3:
                    var modelKey = vehicleMakeList[menuChoices["make"] - 1] + vehicleTypeList[menuChoices["vehicle"] - 1];
                    var modelValues = vehicleModelDict[modelKey];
                    var modelMenuText = "model";
                    menuItemNum = ShowMenuItems(modelValues, modelMenuText);
                    menuChoice = MenuInput(menuItemNum);
                    menuChoices["model"] = menuChoice;
                    menuControl += GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 4:
                    var engineMenuText = "engine";
                    menuItemNum = ShowMenuItems(engineTypeList, engineMenuText);
                    menuChoice = MenuInput(menuItemNum);
                    menuChoices["engine"] = menuChoice;
                    menuControl += GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 5:
                    var colorMenuText = "color";
                    menuItemNum = ShowMenuItems(vehicleColorList, colorMenuText);
                    menuChoice = MenuInput(menuItemNum);
                    menuChoices["color"] = menuChoice;
                    menuControl += GoToPreviousNextOrSameMenu(menuItemNum, menuChoice);
                    break;
                case 6:
                    var year = VehicleYearSelectionMenu();

                    if (year == 1)
                    {
                        menuControl -= 1;
                    }
                    else
                    {
                        displayMenu = false;
                    }

                    break;
                default:
                    break;
            }

        } while (displayMenu);
    }
   
    private int VehicleYearSelectionMenu()
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
                menuChoices["year"] = vehicleYear;
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

    private static int ShowMenuItems(List<string> menuItems, string menuText)
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

    private static int MenuInput(int menuItemNum)
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

    private static int GoToPreviousNextOrSameMenu(int menuItemNum, int menuChoice)
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