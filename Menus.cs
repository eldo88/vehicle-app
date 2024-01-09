namespace vehicle_app;

public class Menus
{
    public Menus(){}
    readonly Dictionary<string, int> menuChoices = [];
    List<string> vehicleTypeList = [];
    List<string> engineTypeList = [];
    List<string> vehicleMakeList = [];
    List<string> vehicleColorList = [];
    readonly Dictionary<string, List<string>> vehicleModelDict = [];
    

    private static void ReadDataFromFile(string filePath, List<string> targetList)
    {
        if (File.Exists(filePath))
        {
            using StreamReader fileReader = new(File.OpenRead(filePath));
            while (!fileReader.EndOfStream)
            {
                var line = fileReader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine($"{filePath} is empty or missing correct data format");
                }
                else
                {
                    var values = line.Split(',');
                    targetList.AddRange(values);
                }
            }
        }
        else
        {
            Console.WriteLine($"File path {filePath} does not exist");
        }
    }

    private static void ReadModelData(string filePath, Dictionary<string, List<string>> targetDict)
    {
        if (File.Exists(filePath))
        {
            using StreamReader fileReader = new(File.OpenRead(filePath));
            while (!fileReader.EndOfStream)
            {
                var makeVehicleTypeKey = fileReader.ReadLine();
                var line = fileReader.ReadLine();

                if (string.IsNullOrWhiteSpace(makeVehicleTypeKey) || string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine($"{filePath} is empty or missing correct data format");
                }
                else
                {
                    var values = line.Split(',');
                    var modelList = new List<string>(values);
                    targetDict.Add(makeVehicleTypeKey, modelList);
                }
            }
        }
        else
        {
            Console.WriteLine($"File path {filePath} does not exist");
        }
    }

    // private void LoadHardCodedData()
    // {
    //     List<string> chevyCar = ["Corvette","Camaro","Bolt"];
    //     vehicleModelDict.Add("ChevroletCar", chevyCar);

    //     List<string> chevyTruck = ["Silverado 1500","Silverado 2500","Colorado"];
    //     vehicleModelDict.Add("ChevroletTruck", chevyTruck);

    //     List<string> chevySuv = ["Tahoe","Suburban","Blazer"];
    //     vehicleModelDict.Add("ChevroletSUV", chevySuv);

    //     List<string> toyotaCar = ["Corrolla","Camry","Prius"];
    //     vehicleModelDict.Add("ToyotaCar", toyotaCar);

    //     List<string> toyotaTruck = ["Tacoma","Tundra"];
    //     vehicleModelDict.Add("ToyotaTruck", toyotaTruck);

    //     List<string> toyotaSuv = ["4Runner","Land Cruiser","Sequoia"];
    //     vehicleModelDict.Add("ToyotaSUV", toyotaSuv);

    //     List<string> fordCar = ["Focus","Escort","Fusion"];
    //     vehicleModelDict.Add("FordCar", fordCar);

    //     List<string> fordTruck = ["F-150","F-250","F-350","Ranger","Maverick"];
    //     vehicleModelDict.Add("FordTruck", fordTruck);

    //     List<string> fordSuv = ["Explorer","Bronco 2 Door","Bronco 4 Door","Escape"];
    //     vehicleModelDict.Add("FordSUV", fordSuv);


    //     vehicleTypeList = ["Car","Truck","SUV"];

    //     engineTypeList = ["V4","V6","V8","V6 Hybrid","Electric","Turbo Diesel"];

    //     vehicleMakeList = ["Toyota","Ford","Chevrolet"];

    //     vehicleColorList = ["White","Black","Silver","Blue","Red","Grey"];
    // }

    private void LoadData()
    {
        string[] modelDataFilePaths = {
            "./data/vehicle-data/toyota-car-data.csv",
            "./data/vehicle-data/toyota-truck-data.csv",
            "./data/vehicle-data/toyota-suv-data.csv",
            "./data/vehicle-data/ford-car-data.csv",
            "./data/vehicle-data/ford-truck-data.csv",
            "./data/vehicle-data/ford-suv-data.csv",
            "./data/vehicle-data/chevrolet-car-data.csv",
            "./data/vehicle-data/chevrolet-truck-data.csv",
            "./data/vehicle-data/chevrolet-suv-data.csv"
        };

        foreach (var filePath in modelDataFilePaths)
        {
            ReadModelData(filePath, vehicleModelDict);
        }

        ReadDataFromFile("./data/vehicle-data/vehicle-type-data.csv", vehicleTypeList);
        ReadDataFromFile("./data/vehicle-data/vehicle-make-data.csv", vehicleMakeList);
        ReadDataFromFile("./data/vehicle-data/engine-data.csv", engineTypeList);
        ReadDataFromFile("./data/vehicle-data/vehicle-color-data.csv", vehicleColorList);
    }

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
        LoadData();

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